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

        private static string GetAllTeamsSql = @"
SELECT
    TeamId, TeamName
FROM
    Team;

SELECT
    TeamMemberId, FirstName, MiddleName, LastName, Title, IsManager
FROM
    TeamMember;";

        private static string GetByTeamIdSql = @"
SELECT
    TeamId, TeamName
FROM
    Team
WHERE
    TeamId = @teamId;

SELECT
    TeamMemberId, FirstName, MiddleName, LastName, Title, IsManager
FROM
    TeamMember
WHERE
    TeamId = @teamId";

        private static string GetAllSql = "SELECT TeamId, TeamName FROM Team ORDER BY TeamName";
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
                using(var results = await connection.QueryMultipleAsync(GetByTeamIdSql, new { teamId }))
                {
                    var team = results.ReadSingle<Team>();

                    var teamMembers = results.Read<TeamMember>().ToList();

                    return new Team(team.TeamId, team.TeamName, team.TeamManagerId, teamMembers);
                }

            }
        }

        public async Task<List<Team>> GetAllAsync()
        {
            using(var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                
                using(var results = await connection.QueryMultipleAsync(GetAllTeamsSql))
                {
                    var resultSet = new List<Team>();
                    var teams = results.Read<Team>().ToList();

                    var teamMembers = results.Read<TeamMember>().ToList();

                    foreach (var t in teams)
                    {
                        var specificTeamMembers = teamMembers.FindAll(tm => tm.TeamId == t.TeamId).ToList();
                        resultSet.Add(new Team(t.TeamId, t.TeamName, t.TeamManagerId, specificTeamMembers));
                    }

                    return resultSet;
                }
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
