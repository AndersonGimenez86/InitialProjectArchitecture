namespace AG.PaymentApp.Domain.Core.Kafka.Producers.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Events;

    public interface ITopicProducer<TMessage>
        where TMessage : Event
    {
        Task<DeliveryMessageReport> ProduceAsync(TMessage message);
    }
}
