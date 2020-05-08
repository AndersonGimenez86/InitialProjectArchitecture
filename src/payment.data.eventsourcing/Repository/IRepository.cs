using System;
using System.Collections.Generic;
using AG.PaymentApp.Domain.Core.Events;

namespace AG.PaymentApp.Data.EventSourcing
{
    public interface IRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}