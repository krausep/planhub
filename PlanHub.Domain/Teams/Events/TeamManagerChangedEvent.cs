using System;

namespace PlanHub.Domain.Teams.Events
{
    public class TeamManagerChangedEvent : IDomainEvent
    {
        public TeamManagerChangedEvent(Guid newTeamManagerId)
        {
            NewTeamManagerId = newTeamManagerId;
        }

        public Guid NewTeamManagerId { get; }
    }
}
