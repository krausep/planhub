using PlanHub.Domain.Entities;

namespace PlanHub.Domain.ObjectiveKeyResults.Services.Definitions
{
    public interface IObjectiveWeightsMustEqual100Service
    {
        bool ObjectiveWeightsEqual100(ObjectiveKeyResult objectiveKeyResult, Objective newObjective);
    }
}
