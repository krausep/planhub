using System;
using System.Collections.Generic;

namespace PlanHub.ReadModels.Okrs.ReadModels
{
    public class GetOkrsForTeamReadModel
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }

        public List<ObjectiveReadModel> Objectives { get; set; }
    }
}
