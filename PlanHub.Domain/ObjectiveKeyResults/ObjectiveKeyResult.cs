using PlanHub.Domain.Entities;
using PlanHub.Domain.Exceptions;
using PlanHub.Domain.ObjectiveKeyResults.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanHub.Domain.ObjectiveKeyResults
{
    public class ObjectiveKeyResult : AggregateBase
    {
        public Guid ObjectiveKeyResultId { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<Objective> Objectives { get; }

        public ObjectiveKeyResult(Guid objectiveKeyResultId, DateTime startDate, DateTime endDate, List<Objective> objectives)
        {
            ObjectiveKeyResultId = objectiveKeyResultId;
            StartDate = startDate;
            EndDate = endDate;
            Objectives = objectives;
        }

        internal void AddNewObjective(Objective objective)
        {
            Objectives.Add(objective);
            RaiseEvent(new NewObjectiveAddedEvent(objective.ObjectiveId));
        }

        public void UpdateObjectiveDescription(Guid objectiveId, string newObjectiveDescription)
        {
            var objective = Objectives.FirstOrDefault(o => o.ObjectiveId  == objectiveId);
            if(objective == null)
            {
                throw new KeyNotFoundException($"ObjectiveId {objectiveId} not found");
            }


        }

        
    }
}
