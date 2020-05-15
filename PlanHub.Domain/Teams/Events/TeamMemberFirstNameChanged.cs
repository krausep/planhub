namespace PlanHub.Domain.Teams.Events
{
    public class TeamMemberFirstNameChanged : IDomainEvent
    {
        public TeamMemberFirstNameChanged(string newFirstName)
        {
            NewFirstName = newFirstName;
        }

        public string NewFirstName { get; }
    }
}
