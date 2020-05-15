using PlanHub.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlanHub.Domain.ObjectiveKeyResults.Services.Definitions
{
    public interface IAddNewObjectiveService
    {
        Task AddNewObjective(Guid objectiveKeyResultId, Objective objective);
    }
}
