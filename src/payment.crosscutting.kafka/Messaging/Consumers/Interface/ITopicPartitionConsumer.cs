namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Consumers.Interface
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITopicPartitionConsumer
    {
        string Name { get; }

        Task StartAsync(CancellationToken cancellationToken);
    }
}
