namespace PlanHub.Domain.ObjectiveKeyResults.Events
{
    public class ObjectiveDescriptionChangedEvent : IDomainEvent
    {
        public ObjectiveDescriptionChangedEvent(string newObjectiveDescription)
        {
            NewObjectiveDescription = newObjectiveDescription;
        }

        public string NewObjectiveDescription { get; }
    }
}
