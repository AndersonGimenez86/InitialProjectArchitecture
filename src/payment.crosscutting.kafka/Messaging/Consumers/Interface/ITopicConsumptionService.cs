namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Consumers.Interface
{
    using System.Threading;

    public interface ITopicConsumerService
    {
        void Start(CancellationToken cancellationToken = default);
    }
}
