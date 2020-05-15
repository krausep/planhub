using PlanHub.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PlanHub.Domain.Repositories
{
    public interface IObjectiveRepository
    {
        Task<Objective> GetAsync(Guid objectiveId);

        Task Update(Objective objective);
    }
}
