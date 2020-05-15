using Kledex.Queries;
using Microsoft.Extensions.DependencyInjection;
using PlanHub.ReadModels.Okrs;
using PlanHub.ReadModels.Okrs.Handlers;
using PlanHub.ReadModels.Okrs.ReadModels;
using PlanHub.ReadModels.Teams;
using PlanHub.ReadModels.Teams.Handlers;

namespace PlanHub.ReadModels.Configuration.DependencyInjection
{
    public static class OkrReadModelsServiceCollectionExtension
    {
        public static IServiceCollection AddOkrReadModels(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandlerAsync<GetTeamQuery, GetTeamReadModel>, GetTeamQueryHandler>();
            services.AddTransient<IQueryHandlerAsync<GetTeamsQuery, GetTeamsReadModel>, GetTeamsQueryHandler>();
            services.AddTransient<IQueryHandlerAsync<GetOkrsForTeamQuery, GetOkrsForTeamReadModel>, GetOkrsForTeamQueryHandler>();
            return services;
        }
    }
}
