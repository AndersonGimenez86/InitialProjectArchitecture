namespace AG.PaymentApp.crosscutting.kafka.Messaging.Producers.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Producers;

    public interface ITopicProducer<TMessage>
        where TMessage : class
    {
        Task<DeliveryMessageReport> ProduceAsync(string key, TMessage message);
    }
}
