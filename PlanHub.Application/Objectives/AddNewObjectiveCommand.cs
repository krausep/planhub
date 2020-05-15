using Kledex.Commands;
using PlanHub.Domain.ValueTypes;
using System;

namespace PlanHub.Application.Objectives
{
    public class AddNewObjectiveCommand : Command
    {
        public Guid ObjectiveKeyResultId { get; }
        public Guid ObjectiveId { get; }
        public string Description { get; }
        public OrganizationLevel OrganizationLevel { get; }

        public AddNewObjectiveCommand(Guid objectiveKeyResultId, Guid objectiveId, string description, OrganizationLevel organizationLevel)
        {
            ObjectiveKeyResultId = objectiveKeyResultId;
            ObjectiveId = objectiveId;
            Description = description;
            OrganizationLevel = organizationLevel;
        }
    }
}
