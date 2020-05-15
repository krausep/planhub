using PlanHub.Domain.Exceptions;
using PlanHub.Domain.ObjectiveKeyResults.Events;
using PlanHub.Domain.ValueTypes;
using System;

namespace PlanHub.Domain.Entities
{
    public class Objective : AggregateBase
    {

        public Guid ObjectiveId { get; }
        public OrganizationLevel OrganizationLevel { get; private set; }
        public string Description { get; private set; }
        public Guid? InheritedFromObjective { get; private set; }
        public int Weight { get; set; }

        public Objective(Guid objectiveId, OrganizationLevel organizationLevel, string description, Guid? inheritedFromObjective, int weight)
        {
            ObjectiveId = objectiveId;
            OrganizationLevel = organizationLevel;
            Description = description;
            InheritedFromObjective = inheritedFromObjective;
            Weight = weight;
        }

        public void ChangeObjectiveDescription(string newObjectiveDescription)
        {
            if (string.IsNullOrWhiteSpace(newObjectiveDescription))
            {
                throw new DomainValidationException("Objective description must not be empty");
            }

            if (newObjectiveDescription.Length > 200)
            {
                throw new DomainValidationException("Objective description must be less than 200 characters");
            }

            Description = newObjectiveDescription;
            RaiseEvent(new ObjectiveDescriptionChangedEvent(newObjectiveDescription));
        }
    }
}
