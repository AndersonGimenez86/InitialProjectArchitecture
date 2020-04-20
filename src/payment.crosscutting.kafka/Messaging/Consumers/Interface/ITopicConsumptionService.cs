namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Interface
{
    using System.Threading;

    public interface ITopicConsumerService
    {
        void Start(CancellationToken cancellationToken = default);
    }
}
