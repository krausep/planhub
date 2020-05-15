using Kledex.Commands;
using Microsoft.Extensions.DependencyInjection;
using PlanHub.Application.KeyResults;
using PlanHub.Application.KeyResults.CommandHandlers;
using PlanHub.Application.Objectives;
using PlanHub.Application.Objectives.CommandHandlers;

namespace PlanHub.Application.Configuration.DependencyInjection
{
    public static class PlanHubApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddPlanHubApplication(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandlerAsync<AddNewKeyResultCommand>, AddNewKeyResultCommandHandler>();
            services.AddTransient<ICommandHandlerAsync<AddNewObjectiveCommand>, AddNewObjectiveCommandHandler>();
            return services;
        }
    }
}
