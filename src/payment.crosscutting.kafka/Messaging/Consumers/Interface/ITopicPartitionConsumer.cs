namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Interface
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITopicPartitionConsumer
    {
        string Name { get; }

        Task StartAsync(CancellationToken cancellationToken);
    }
}
