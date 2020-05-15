using System;

namespace PlanHub.Domain.Teams.Events
{
    public class TeamMemberRemoved : IDomainEvent
    {
        public Guid TeamId { get; }
        public Guid RemovedTeamMemberId { get; }

        public TeamMemberRemoved(Guid teamId, Guid removedTeamMemberId)
        {
            TeamId = teamId;
            RemovedTeamMemberId = removedTeamMemberId;
        }

    }
}
