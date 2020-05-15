using Dapper;
using Kledex.Queries;
using Microsoft.Extensions.Configuration;
using PlanHub.ReadModels.Teams.ReadModels;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PlanHub.ReadModels.Teams.Handlers
{
    public class GetTeamsQueryHandler : IQueryHandlerAsync<GetTeamsQuery, GetTeamsReadModel>
    {
        private readonly IConfiguration _configuration;
        private static string GetSql = @"
SELECT
    TeamId, TeamName
FROM
    Team
ORDER BY TeamName;

SELECT
    TeamMemberId, TeamId, FirstName, MiddleName, LastName, Title, IsManager
FROM
    TeamMember;";
    
        public GetTeamsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GetTeamsReadModel> HandleAsync(GetTeamsQuery query)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                using (var results = await connection.QueryMultipleAsync(GetSql))
                {
                    var teams = results.Read<TeamReadModel>().ToList();
                    var teamMembers = results.Read<TeamMemberReadModel>().ToList();
                    foreach (var team in teams)
                    {
                        team.TeamMembers = teamMembers.FindAll(tm => tm.TeamId == team.TeamId);
                    }

                    return new GetTeamsReadModel(teams);
                }
            }
        }
    }
}
