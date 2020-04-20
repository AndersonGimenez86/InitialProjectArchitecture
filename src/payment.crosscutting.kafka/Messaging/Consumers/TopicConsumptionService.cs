namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Interface;

    public class TopicConsumerService : ITopicConsumerService
    {
        //private readonly ILog log;
        private readonly IEnumerable<ITopicPartitionConsumer> topicPartitionConsumers;

        public TopicConsumerService(IEnumerable<ITopicPartitionConsumer> topicPartitionConsumers)
        {
            this.topicPartitionConsumers = topicPartitionConsumers ?? throw new System.ArgumentNullException(nameof(topicPartitionConsumers));
        }

        public void Start(CancellationToken cancellationToken = default)
        {
            foreach (var consumer in this.topicPartitionConsumers)
            {
                Task.Factory.StartNew(async (o) =>
                {
                    (var c, var token) = ((ITopicPartitionConsumer, CancellationToken))o;
                    try
                    {
                        await c.StartAsync(token);
                    }
                    catch (Exception exception)
                    {
                        //this.log.Error($"Failed to start consumer! Consumer name: {c.Name}.", exception);
                        throw;
                    }
                },
                (consumer, cancellationToken),
                cancellationToken,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default).ConfigureAwait(false);
            }
        }
    }
}
