using System;
using System.Collections.Generic;
using AG.PaymentApp.Domain.Core.Events;

namespace AG.PaymentApp.Data.EventSourcing
{
    public class Repository : IRepository
    {
        //private readonly EventStoreSqlContext _context;

        //public EventStoreSqlRepository(EventStoreSqlContext context)
        //{
        //    _context = context;
        //}

        public IList<StoredEvent> All(Guid aggregateId)
        {
            //return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
            return null;
        }

        public void Store(StoredEvent theEvent)
        {
            //_context.StoredEvent.Add(theEvent);
            //_context.SaveChanges();
        }

        public void Dispose()
        {
            //_context.Dispose();
        }
    }
}