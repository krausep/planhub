using System;

namespace PlanHub.ReadModels.Teams.ReadModels
{
    public class TeamMemberReadModel
    {
        public Guid TeamId { get; set; }
        public Guid TeamMemberId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public bool IsManager { get; set; }
    }
}
