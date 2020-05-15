using PlanHub.Domain.Exceptions;
using PlanHub.Domain.Teams.Events;
using System;

namespace PlanHub.Domain.Teams
{
    public class TeamMember : AggregateBase
    {
        public Guid TeamMemberId { get; }
        public Guid TeamId { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Title { get; private set; }
        public bool IsManager { get; private set; }

        public TeamMember(Guid teamMemberId, Guid teamId, string firstName, string middleName, string lastName, string title, bool isManager)
        {
            TeamMemberId = teamMemberId;
            TeamId = teamId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Title = title;
            IsManager = isManager;
        }

        public void ChangeFirstName(string newFirstName)
        {
            if(string.IsNullOrWhiteSpace(newFirstName))
            {
                throw new DomainValidationException("First name must not be blank or empty");
            }

            if(newFirstName.Length > 50)
            {
                throw new DomainValidationException("First name must be less than 50 characters");
            }

            FirstName = newFirstName;
            RaiseEvent(new TeamMemberFirstNameChanged(newFirstName));
        }

        public void ChangeTeam(Guid newTeamId)
        {
            TeamId = newTeamId;
            RaiseEvent(new TeamMemberTeamChangedEvent(newTeamId));
        }
    }
}
