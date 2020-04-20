namespace AG.PaymentApp.Domain.Core.Events.Interface
{
    public interface IEventStore
    {
        void Save<T>(T newEvent) where T : Event;
    }
}