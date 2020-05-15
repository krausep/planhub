using PlanHub.Domain.ValueTypes;
using System;

namespace PlanHub.WebApi.RequestModels
{
    public class NewObjectiveRequestModel
    {
        public Guid ObjectiveKeyResultId { get; set; }
        public string Description { get; set; }
        public OrganizationLevel OrganizationLevel { get; set; }
    }
}
