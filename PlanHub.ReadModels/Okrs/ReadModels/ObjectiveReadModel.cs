using PlanHub.Domain.ValueTypes;
using System;

namespace PlanHub.ReadModels.Okrs.ReadModels
{
    public class ObjectiveReadModel
    {
        public Guid ObjectiveId { get; set; }
        public Guid ObjectiveKeyResultId { get; set; }
        public string Description { get; set; }
        public OrganizationLevel OrganizationLevelId { get; set; }
        public int? PercentageWeight { get; set; }
    }
}
