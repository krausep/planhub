using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlanHub.Domain.Repositories;
using PlanHub.Domain.Teams;
using PlanHub.Domain.Teams.Events;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PlanHub.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TeamRepository> _logger;

        private static string GetByTeamIdSql = "SELECT TeamId, TeamName FROM Team WHERE TeamId = @teamId";
        private static string GetAllSql = "SELECT TeamId, TeamName FROM Team ORDER BY TeamName";
        private static string GetTeamMembersByTeamIdSql = "SELECT TeamMemberId, TeamId FROM TeamMembership WHERE TeamId = @teamId";
        private static string GetTeamMembersSql = "SELECT TeamMemberId, TeamId FROM TeamMembership";
        private static string AddTeamMemberSql = "INSERT INTO TeamMembership(TeamMemberId, TeamId) VALUES (@teamMemberId, @teamId)";
        private static string UpdateTeamSql = @"UPDATE Team SET TeamName = @teamName WHERE TeamId = @teamId";

        public TeamRepository(IConfiguration configuration, ILogger<TeamRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<Team> GetByTeamId(Guid teamId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                var team = await connection.QueryFirstAsync<Team>(GetByTeamIdSql, new { teamId });

                var teamMembers = (await connection.QueryAsync<TeamMembership>(GetTeamMembersByTeamIdSql)).ToList();

                return new Team(team.TeamId, team.TeamName, team.TeamManagerId, teamMembers);
            }
        }

        public async Task<List<Team>> GetAllAsync()
        {
            using(var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                var resultSet = new List<Team>();
                var teams = (await connection.QueryAsync<Team>(GetAllSql)).ToList();

                var teamMembers = (await connection.QueryAsync<TeamMembership>(GetTeamMembersSql)).ToList();

                foreach(var t in teams)
                {
                    var specificTeamMembers = teamMembers.FindAll(tm => tm.TeamId == t.TeamId).ToList();
                    resultSet.Add(new Team(t.TeamId, t.TeamName, t.TeamManagerId, specificTeamMembers));
                }

                return resultSet;
            }
        }

        public async Task Update(Team team)
        {
            using(var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        // See if there are any newly added team members
                        foreach (var @event in team.GetPendingEvents().Where(e => e is TeamMemberAddedEvent))
                        {
                            var addedEvent = @event as TeamMemberAddedEvent;
                            await connection.ExecuteAsync(AddTeamMemberSql,
                                new
                                {
                                    TeamMemberId = addedEvent.NewTeamMemberId,
                                    addedEvent.TeamId
                                });
                        }

                        // update the team
                        await connection.ExecuteAsync(UpdateTeamSql, team.TeamId);
                    }
                    catch(SqlException e)
                    {
                        _logger.LogError(e, $"SqlException when trying to update team {team.TeamId}");
                        await transaction.RollbackAsync();
                    }

                }
            }
        }
    }
}
