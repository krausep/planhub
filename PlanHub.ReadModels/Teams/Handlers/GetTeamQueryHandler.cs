using Dapper;
using Kledex.Queries;
using Microsoft.Extensions.Configuration;
using PlanHub.ReadModels.Teams.ReadModels;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PlanHub.ReadModels.Teams.Handlers
{
    public class GetTeamQueryHandler : IQueryHandlerAsync<GetTeamQuery, GetTeamReadModel>
    {
        private readonly IConfiguration _configuration;

        private static string GetSql = @"
SELECT
    TeamId, TeamName
FROM
    Team
WHERE TeamId = @teamId;

SELECT
    tm.TeamMemberId, tship.TeamId, tm.FirstName, tm.MiddleName, tm.LastName, tm.Title, tm.IsManager
FROM
    TeamMembership tship
LEFT JOIN TeamMember tm
    ON tm.TeamMemberId = tship.TeamMemberId
WHERE tship.TeamId = @teamId;";

        public GetTeamQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GetTeamReadModel> HandleAsync(GetTeamQuery query)
        {
            using(var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                var results = await connection.QueryMultipleAsync(GetSql, new { query.TeamId });
                var team = results.ReadSingle<GetTeamReadModel>();
                var teamMembers = results.Read<TeamMemberReadModel>().ToList();
                team.TeamMembers = teamMembers;

                return team;
            }
        }
    }
}
