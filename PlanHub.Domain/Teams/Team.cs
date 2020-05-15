using PlanHub.Domain.Exceptions;
using PlanHub.Domain.Teams.Events;
using System;
using System.Collections.Generic;

namespace PlanHub.Domain.Teams
{
    public class Team : AggregateBase
    {
        public Guid TeamId { get; }
        public string TeamName { get; private set; }
        public Guid TeamManagerId { get; private set; }

        public List<TeamMember> TeamMembers { get; }

        public Team(Guid teamId, string teamName, Guid teamManagerId, List<TeamMember> teamMembers)
        {
            TeamId = teamId;
            TeamName = teamName;
            TeamManagerId = teamManagerId;
            TeamMembers = teamMembers;
        }

        public void ChangeTeamName(string newTeamName)
        {
            if(string.IsNullOrWhiteSpace(newTeamName))
            {
                throw new DomainValidationException("Team name must be at least 1 non-whitespace character");
            }

            if(newTeamName.Length > 100)
            {
                throw new DomainValidationException("Team name must be 100 characters or fewer");
            }

            TeamName = newTeamName;

            RaiseEvent(new TeamNameChangedEvent(newTeamName));
        }

        public void ChangeTeamManager(Guid newTeamManagerId)
        {
            TeamManagerId = newTeamManagerId;
            RaiseEvent(new TeamManagerChangedEvent(newTeamManagerId));
        }
    }
}
