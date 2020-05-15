using PlanHub.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanHub.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> GetByTeamId(Guid teamId);

        Task<List<Team>> GetAllAsync();

        Task Update(Team team);
    }
}
