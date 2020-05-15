using Kledex.Commands;
using PlanHub.Domain.ObjectiveKeyResults.Services.Definitions;
using System.Threading.Tasks;

namespace PlanHub.Application.Objectives.CommandHandlers
{
    public class AddNewObjectiveCommandHandler : ICommandHandlerAsync<AddNewObjectiveCommand>
    {
        private readonly IAddNewObjectiveService _addNewObjectiveService;

        public AddNewObjectiveCommandHandler(IAddNewObjectiveService addNewObjectiveService)
        {
            _addNewObjectiveService = addNewObjectiveService;
        }
        public async Task<CommandResponse> HandleAsync(AddNewObjectiveCommand command)
        {
            await _addNewObjectiveService.AddNewObjective(command.ObjectiveKeyResultId, new Domain.Entities.Objective(command.ObjectiveId, command.OrganizationLevel, command.Description, null, 0));

            return new CommandResponse();
        }
    }
}
