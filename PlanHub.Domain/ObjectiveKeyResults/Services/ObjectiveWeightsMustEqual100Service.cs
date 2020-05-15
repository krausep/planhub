using PlanHub.Domain.Entities;
using PlanHub.Domain.ObjectiveKeyResults.Services.Definitions;
using PlanHub.Domain.Repositories;
using System.Linq;

namespace PlanHub.Domain.ObjectiveKeyResults.Services
{
    public class ObjectiveWeightsMustEqual100Service : IObjectiveWeightsMustEqual100Service
    {
        IObjectiveKeyResultRepository _objectiveKeyResultRepository;

        public ObjectiveWeightsMustEqual100Service(IObjectiveKeyResultRepository objectiveKeyResultRepository)
        {
            _objectiveKeyResultRepository = objectiveKeyResultRepository;
        }

        public bool ObjectiveWeightsEqual100(ObjectiveKeyResult objectiveKeyResult, Objective newObjective)
        {
            var currentSum = objectiveKeyResult.Objectives.Sum(o => o.Weight);

            return currentSum + newObjective.Weight != 100;
        }
    }
}
