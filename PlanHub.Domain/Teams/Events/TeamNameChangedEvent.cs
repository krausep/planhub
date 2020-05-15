namespace PlanHub.Domain.Teams.Events
{
    public class TeamNameChangedEvent : IDomainEvent
    {
        public string NewTeamName { get; }

        public TeamNameChangedEvent(string newTeamName)
        {
            NewTeamName = newTeamName;
        }        
    }
}
