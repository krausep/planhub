using System.Collections.Generic;

namespace PlanHub.ReadModels.Teams
{
    public class GetTeamsReadModel
    {
        public List<TeamReadModel> Teams { get; set; }

        public GetTeamsReadModel(List<TeamReadModel> teams)
        {
            Teams = teams;
        }
    }
}
