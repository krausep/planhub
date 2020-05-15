using System;

namespace PlanHub.Domain.ObjectiveKeyResults.Events
{
    public class NewObjectiveAddedEvent : IDomainEvent
    {
        public Guid NewObjectiveId { get; }
        public NewObjectiveAddedEvent(Guid newObjectiveId)
        {
            NewObjectiveId = newObjectiveId;
        }
    }
}
