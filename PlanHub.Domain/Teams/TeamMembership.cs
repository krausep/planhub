using System;

namespace PlanHub.Domain.Teams
{
    public class TeamMembership
    {
        public Guid TeamMemberId { get; private set; }
        public Guid TeamId { get; private set; }

        public TeamMembership(Guid teamMemberId, Guid teamId)
        {
            TeamMemberId = teamMemberId;
            TeamId = teamId;
        }
    }
}
