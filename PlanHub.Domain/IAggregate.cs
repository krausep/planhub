using System.Collections;
using System.Collections.Generic;

namespace PlanHub.Domain
{
    public interface IAggregate
    {
        IEnumerable<IDomainEvent> GetPendingEvents();
    }
}
