using Dapper;
using Microsoft.Extensions.Configuration;
using PlanHub.Domain.Repositories;
using PlanHub.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PlanHub.Data.Repositories
{
    public class TeamMembershipRepository : ITeamMembershipRepository
    {
        private readonly IConfiguration _configuration;
        private static readonly string GetTeamMembershipByTeamIdSql = "SELECT TeamMemberId, TeamId FROM TeamMembership WHERE TeamId = @teamId";
        private static readonly string GetTeamMembershipByTeamMemberIdSql = "SELECT TeamMemberId, TeamId FROM TeamMembership WHERE TeamMemberId = @teamMemberId";

        public TeamMembershipRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<TeamMembership>> GetTeamMembershipByTeamIdAsync(Guid teamId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                return (await connection.QueryAsync<TeamMembership>(GetTeamMembershipByTeamIdSql, teamId)).ToList();
            }
        }

        public async Task<TeamMembership> GetTeamMembershipByTeamMemberId(Guid teamMemberId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                return await connection.QueryFirstAsync<TeamMembership>(GetTeamMembershipByTeamMemberIdSql, teamMemberId);
            }
        }
    }
}
