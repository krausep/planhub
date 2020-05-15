using System;
using System.Collections.Generic;

namespace PlanHub.Domain
{
    public class AggregateBase : IAggregate
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        protected void RaiseEvent<TDomainEvent>(TDomainEvent domainEvent)
            where TDomainEvent : IDomainEvent
        {
            _domainEvents.Add(domainEvent);
        }

        public IEnumerable<IDomainEvent> GetPendingEvents()
        {
            throw new NotImplementedException();
        }
    }
}
