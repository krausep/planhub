using Kledex.Queries;
using System;

namespace PlanHub.ReadModels.Teams
{
    public class GetTeamQuery : IQuery<GetTeamReadModel>
    {
        public Guid TeamId { get; set; }

        public GetTeamQuery(Guid teamId)
        {
            TeamId = teamId;
        }
    }
}
