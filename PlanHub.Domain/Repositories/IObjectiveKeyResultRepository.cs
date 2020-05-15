using PlanHub.Domain.ObjectiveKeyResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlanHub.Domain.Repositories
{
    public interface IObjectiveKeyResultRepository
    {
        Task<ObjectiveKeyResult> GetObjectiveKeyResultAsync(Guid objectiveKeyResultId);
        Task UpdateAsync(ObjectiveKeyResult objectiveKeyResult);
    }
}
