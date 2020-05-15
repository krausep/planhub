using Kledex.Commands;
using System;

namespace PlanHub.Application.Teams
{
    public class AddTeamMemberCommand : Command
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }

        public AddTeamMemberCommand(Guid teamId, string teamName)
        {
            TeamId = teamId;
            TeamName = teamName;
        }
    }
}

