using Kledex.Commands;
using System;
using System.Threading.Tasks;

namespace PlanHub.Application.KeyResults.CommandHandlers
{
    public class AddNewKeyResultCommandHandler : ICommandHandlerAsync<AddNewKeyResultCommand>
    {
        public async Task<CommandResponse> HandleAsync(AddNewKeyResultCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
