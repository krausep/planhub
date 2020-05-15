using System;

namespace PlanHub.Domain.Teams.Events
{
    public class TeamMemberAddedEvent : IDomainEvent
    {
        public Guid TeamId { get; }
        public Guid NewTeamMemberId { get; }

        public TeamMemberAddedEvent(Guid teamId, Guid newTeamMemberId)
        {
            TeamId = teamId;
            NewTeamMemberId = newTeamMemberId;
        }

    }
}
