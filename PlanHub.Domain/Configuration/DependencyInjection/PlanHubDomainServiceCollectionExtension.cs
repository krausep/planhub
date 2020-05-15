using Microsoft.Extensions.DependencyInjection;
using PlanHub.Domain.ObjectiveKeyResults.Services;
using PlanHub.Domain.ObjectiveKeyResults.Services.Definitions;

namespace PlanHub.Domain.Configuration.DependencyInjection
{
    public static class PlanHubDomainServiceCollectionExtension
    {
        public static IServiceCollection AddPlanHubDomain(this IServiceCollection services)
        {
            services.AddTransient<IAddNewObjectiveService, AddNewObjectiveService>();
            return services;
        }
    }
}
