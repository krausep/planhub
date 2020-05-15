using PlanHub.ReadModels.Teams.ReadModels;
using System;
using System.Collections.Generic;

namespace PlanHub.ReadModels.Teams
{
    public class TeamReadModel
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }

        public List<TeamMemberReadModel> TeamMembers { get; set; }
    }
}
