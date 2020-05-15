using Dapper;
using Microsoft.Extensions.Configuration;
using PlanHub.Domain.ObjectiveKeyResults;
using PlanHub.Domain.Repositories;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PlanHub.Data.Repositories
{
    public class ObjectiveKeyResultRepository : IObjectiveKeyResultRepository
    {
        private readonly IConfiguration _configuration;
        public ObjectiveKeyResultRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static string GetSql = @"SELECT ObjectiveKeyResultId, StartDate, EndDate FROM ObjectiveKeyResut
            WHERE ObjectiveKeyResultId = @objectiveKeyResultId";
        public async Task<ObjectiveKeyResult> GetObjectiveKeyResultAsync(Guid objectiveKeyResultId)
        {
            using(var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                return await connection.QueryFirstAsync<ObjectiveKeyResult>(GetSql, new { objectiveKeyResultId });
            }
        }

        public async Task UpdateAsync(ObjectiveKeyResult objectiveKeyResult)
        {
            throw new NotImplementedException();
        }
    }
}
