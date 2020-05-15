using Kledex.Queries;
using PlanHub.ReadModels.Okrs.ReadModels;
using System;

namespace PlanHub.ReadModels.Okrs
{
    public class GetOkrsForTeamQuery : IQuery<GetOkrsForTeamReadModel>
    {
        public Guid TeamId { get; }

        public GetOkrsForTeamQuery(Guid teamId)
        {
            TeamId = teamId;
        }
    }
}
