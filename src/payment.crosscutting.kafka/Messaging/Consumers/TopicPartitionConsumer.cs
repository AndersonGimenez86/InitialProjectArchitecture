namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Consumers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Consumers.Interface;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Serialization;
    using Confluent.Kafka;

    internal class TopicPartitionConsumer<TMessage> : ITopicPartitionConsumer
        where TMessage : class
    {
        private readonly IConsumer<string, byte[]> consumer;
        //private readonly ILogger logger;
        private readonly IMessageHandler<TMessage> messageHandler;
        private readonly IMessageSerializer<TMessage> messageSerializer;
        private readonly string topicName;

        public TopicPartitionConsumer(
            string name,
            string topicName,
            IConsumer<string, byte[]> consumer,
            IMessageSerializer<TMessage> messageSerializer,
            IMessageHandler<TMessage> messageHandler)
        {
            this.Name = name;
            this.topicName = topicName;
            this.consumer = consumer;
            this.messageSerializer = messageSerializer;
            this.messageHandler = messageHandler;
        }

        public string Name { get; }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            this.consumer.Subscribe(this.topicName);

            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = this.consumer.Consume(cancellationToken);

                TMessage message = default;
                try
                {
                    message = this.messageSerializer.Deserialize(consumeResult.Value);
                }
                catch (Exception exception)
                {
                    //this.logger.WriteLog(new DeserializationFailedLog(
                    //    consumeResult.Topic,
                    //    consumeResult.Partition.Value,
                    //    consumeResult.Offset.Value,
                    //    consumeResult.IsPartitionEOF,
                    //    consumeResult.Key,
                    //    exception));

                    this.consumer.Pause(this.consumer.Assignment);
                }

                try
                {
                    if (message != null)
                    {
                        await this.messageHandler.HandleAsync(message);
                        consumer.Commit();
                    }
                }
                catch (Exception exception)
                {
                    //this.logger.WriteLog(new MessageHandlingFailedLog(
                    //           consumeResult.Topic,
                    //           consumeResult.Partition.Value,
                    //           consumeResult.Offset.Value,
                    //           consumeResult.IsPartitionEOF,
                    //           consumeResult.Key,
                    //           exception));

                    this.consumer.Pause(this.consumer.Assignment);
                }
            }
        }

        private void LogCommitFailure(KafkaException kafkaException, TimeSpan timeSpan, int retryCount)
        {
            //this.logger.WriteLog(new KafkaCommitFailLog(this.topicName,
            //    timeSpan.TotalSeconds,
            //    retryCount,
            //    kafkaException));
        }
    }
}