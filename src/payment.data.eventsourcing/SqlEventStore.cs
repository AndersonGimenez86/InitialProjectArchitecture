using System.Text.Json;
using AG.PaymentApp.Domain.Core.Events;
using AG.PaymentApp.Domain.Core.Events.Interface;
using AG.PaymentApp.Domain.Interface;

namespace AG.PaymentApp.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IRepository _eventStoreRepository;
        private readonly IUser _user;

        public SqlEventStore(IRepository eventStoreRepository, IUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonSerializer.Serialize(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Name);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}