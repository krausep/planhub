using PlanHub.Domain.Entities;
using PlanHub.Domain.Exceptions;
using PlanHub.Domain.ObjectiveKeyResults.Services.Definitions;
using PlanHub.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PlanHub.Domain.ObjectiveKeyResults.Services
{
    public class AddNewObjectiveService : IAddNewObjectiveService
    {
        private readonly IObjectiveKeyResultRepository _objectiveKeyResultRepository;
        private readonly IObjectiveWeightsMustEqual100Service _objectiveWeightsMustEqual100Service;

        public AddNewObjectiveService(IObjectiveKeyResultRepository objectiveKeyResultRepository, IObjectiveWeightsMustEqual100Service objectiveWeightsMustEqual100Service)
        {
            _objectiveKeyResultRepository = objectiveKeyResultRepository;
            _objectiveWeightsMustEqual100Service = objectiveWeightsMustEqual100Service;
        }

        public async Task AddNewObjective(Guid objectiveKeyResultId, Objective objective)
        {
            var objectiveKeyResult = await _objectiveKeyResultRepository.GetObjectiveKeyResultAsync(objectiveKeyResultId);

            if (!_objectiveWeightsMustEqual100Service.ObjectiveWeightsEqual100(objectiveKeyResult, objective))
            {
                throw new DomainValidationException("Sum of objectives must equal 100 percent");
            }

            objectiveKeyResult.AddNewObjective(objective);

            await _objectiveKeyResultRepository.UpdateAsync(objectiveKeyResult);
        }
    }
}
