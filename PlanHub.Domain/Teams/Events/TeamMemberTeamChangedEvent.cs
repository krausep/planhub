using System;

namespace PlanHub.Domain.Teams.Events
{
    public class TeamMemberTeamChangedEvent : IDomainEvent
    {
        public Guid NewTeamId { get; }

        public TeamMemberTeamChangedEvent(Guid newTeamId)
        {
            NewTeamId = newTeamId;
        }

    }
}
