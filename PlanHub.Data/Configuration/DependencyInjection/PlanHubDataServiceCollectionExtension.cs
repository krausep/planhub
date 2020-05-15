using Microsoft.Extensions.DependencyInjection;
using PlanHub.Data.Repositories;
using PlanHub.Domain.ObjectiveKeyResults.Services;
using PlanHub.Domain.ObjectiveKeyResults.Services.Definitions;
using PlanHub.Domain.Repositories;

namespace PlanHub.Data.Configuration.DependencyInjection
{
    public static class PlanHubDataServiceCollectionExtension
    {
        public static IServiceCollection AddPlanHubData(this IServiceCollection services)
        {
            services.AddTransient<IObjectiveKeyResultRepository, ObjectiveKeyResultRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IObjectiveRepository, ObjectiveRepository>();
            services.AddTransient<IObjectiveWeightsMustEqual100Service, ObjectiveWeightsMustEqual100Service>();
            return services;
        }
    }
}
