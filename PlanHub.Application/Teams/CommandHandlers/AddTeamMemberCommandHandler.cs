using Kledex.Commands;
using PlanHub.Domain.Teams.Services.Definitions;
using System.Threading.Tasks;

namespace PlanHub.Application.Teams.CommandHandlers
{
    public class AddTeamMemberCommandHandler : ICommandHandlerAsync<AddNewTeamMemberCommand>
    {
        private readonly IAddNewTeamMemberService _addNewTeamMemberService;
        public AddTeamMemberCommandHandler(IAddNewTeamMemberService addNewTeamMemberService)
        {
            _addNewTeamMemberService = addNewTeamMemberService;
        }
        public async Task<CommandResponse> HandleAsync(AddNewTeamMemberCommand command)
        {

            await _addNewTeamMemberService.AddTeamMemberToTeam(command.TeamId, command.TeamMemberId);

            return new CommandResponse();
        }
    }
}
