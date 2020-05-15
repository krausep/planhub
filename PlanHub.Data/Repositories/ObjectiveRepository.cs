using Dapper;
using Microsoft.Extensions.Configuration;
using PlanHub.Domain.Entities;
using PlanHub.Domain.Repositories;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PlanHub.Data.Repositories
{
    public class ObjectiveRepository : IObjectiveRepository
    {
        private readonly IConfiguration _configuration;

        private static string GetSql = "SELECT ObjectiveId, ObjectiveKeyResultId, Description, Level FROM Objective WHERE ObjectiveId = @objectiveId";
        private static string UpdateSql = "UPDATE Objective SET Description = @description, Level = @level WHERE ObjectiveId = @objectiveId";

        public ObjectiveRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Objective> GetAsync(Guid objectiveId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                return await connection.QueryFirstAsync<Objective>(GetSql, objectiveId);
            }
        }

        public async Task Update(Objective objective)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PlanHub")))
            {
                await connection.ExecuteAsync(UpdateSql, new { objective.Description, objective.OrganizationLevel });
            }
        }
    }
}
