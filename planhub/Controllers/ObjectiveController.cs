using Kledex.Commands;
using Microsoft.AspNetCore.Mvc;
using PlanHub.Application.Objectives;
using PlanHub.Domain.Entities;
using PlanHub.WebApi.RequestModels;
using System;
using System.Threading.Tasks;

namespace PlanHub.WebApi.Controllers
{
    public class ObjectiveController : ControllerBase
    {
        private readonly ICommandHandlerAsync<AddNewObjectiveCommand> _addNewObjectiveCommandHandler;
        public ObjectiveController(ICommandHandlerAsync<AddNewObjectiveCommand> addNewObjectiveCommandHandler)
        {
            _addNewObjectiveCommandHandler = addNewObjectiveCommandHandler;
        }

        [HttpPost]
        [Route("/api/objective/{objectiveId}")]
        public async Task UpdateObjective(Objective objective)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("/api/objective/add")]
        public async Task AddObjective(NewObjectiveRequestModel newObjective)
        {
            // Typically a bad idea to generate a new random Guid. We would want a sequential Guid (now GuidComb in dotnet core)
            var command = new AddNewObjectiveCommand(newObjective.ObjectiveKeyResultId, Guid.NewGuid(), newObjective.Description, newObjective.OrganizationLevel);
            await _addNewObjectiveCommandHandler.HandleAsync(command);
        }

    }
}
