using Kledex.Commands;
using System;

namespace PlanHub.Application.Teams
{
    public class AddNewTeamMemberCommand : Command
    {
        public Guid TeamId { get; set; }
        public Guid TeamMemberId { get; set; }
    }
}
