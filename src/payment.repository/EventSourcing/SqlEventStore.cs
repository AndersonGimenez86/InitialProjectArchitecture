using System;
using AG.PaymentApp.Domain.Core.Events;
using AG.PaymentApp.Domain.Core.Events.Interface;

namespace AG.Payment.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        //private readonly IEventStoreRepository _eventStoreRepository;
        //private readonly IUser _user;

        //public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        //{
        //    _eventStoreRepository = eventStoreRepository;
        //    _user = user;
        //}

        //public void Save<T>(T theEvent) where T : Event
        //{
        //    var serializedData = JsonSerializer.Serialize(theEvent);

        //    var storedEvent = new StoredEvent(
        //        theEvent,
        //        serializedData,
        //        _user.Name);

        //    _eventStoreRepository.Store(storedEvent);
        //}
        public void Save<T>(T newEvent) where T : Event
        {
            throw new NotImplementedException();
        }
    }
}
