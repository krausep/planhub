using Dapper;
using Kledex.Queries;
using Microsoft.Extensions.Configuration;
using PlanHub.ReadModels.Okrs.ReadModels;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PlanHub.ReadModels.Okrs.Handlers
{
    public class GetOkrsForTeamQueryHandler : IQueryHandlerAsync<GetOkrsForTeamQuery, GetOkrsForTeamReadModel>
    {
        private readonly IConfiguration _configuration;

        private static string GetSql = @"
SELECT
    TeamId, TeamName
FROM
    Team
WHERE TeamId = @teamId;

SELECT
    o.ObjectiveId, o.ObjectiveKeyResultId, o.Description, o.OrganizationLevelId, o.PercentageWeight
FROM
    Objective o
INNER JOIN CompanyObjective co
    ON o.ObjectiveId = co.ObjectiveId
UNION
SELECT
    o.ObjectiveId, o.ObjectiveKeyResultId, o.Description, o.OrganizationLevelId, o.PercentageWeight
FROM
    Objective o
INNER JOIN TeamObjective tobj
    ON o.ObjectiveId = tobj.ObjectiveId
WHERE
    tobj.TeamId = @teamId
ORDER
    BY Description
";
        public GetOkrsForTeamQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<GetOkrsForTeamReadModel> HandleAsync(GetOkrsForTeamQuery query)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                using (var results = await connection.QueryMultipleAsync(GetSql, new { query.TeamId }))
                {
                    var okrTeamModel = results.ReadSingle<GetOkrsForTeamReadModel>();

                    okrTeamModel.Objectives = results.Read<ObjectiveReadModel>().ToList();

                    return okrTeamModel;
                }
            }
        }
    }
}
