namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Compression;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Serializers;
    using Confluent.Kafka;

    internal class KafkaConsumerFactory : IDisposable
    {
        //private readonly ILog log;

        private readonly List<IConsumer<string, byte[]>> consumers = new List<IConsumer<string, byte[]>>();

        public KafkaConsumerFactory()
        {
        }

        public IConsumer<string, byte[]> CreateConsumer(ClusterSettings clusterSettings, TopicConsumerSettings topicConsumerSettings)
        {
            if (topicConsumerSettings == null)
            {
                throw new ArgumentNullException(nameof(topicConsumerSettings));
            }

            if (!topicConsumerSettings.Enabled)
            {
                return null;
            }

            var config = clusterSettings.ToClientConfig<ConsumerConfig>(c =>
            {
                c.GroupId = topicConsumerSettings.GroupId;
                c.AutoOffsetReset = (AutoOffsetReset)topicConsumerSettings.AutoOffsetReset;
                c.EnableAutoCommit = false;
            });

            var builder = new ConsumerBuilder<string, byte[]>(config)
                .SetLogHandler(this.OnLog)
                .SetErrorHandler(this.OnError)
                .SetStatisticsHandler(this.OnStatistics)
                .SetOffsetsCommittedHandler(this.OnCommitted)
                .SetPartitionsRevokedHandler((c, tpo) => this.OnPartitionsRevoked(c, tpo))
                .SetPartitionsAssignedHandler((c, tpo) => this.OnPartitionsAssigned(c, tpo))
                .SetKeyDeserializer(Utf8Serializer.Instance);

            if (CompressionHandlerFactory.ResolveCompressionHandler(topicConsumerSettings.MessageCompressionType, out var compressionHandler))
            {
                builder.SetValueDeserializer(compressionHandler);
            }

            var consumer = builder.Build();

            this.consumers.Add(consumer);

            return consumer;
        }

        public void Dispose()
        {
            foreach (var consumer in this.consumers)
            {
                try
                {
                    consumer.Dispose();
                }
                catch
                {

                }
            }
        }

        private void OnLog(IConsumer<string, byte[]> consumer, LogMessage logMessage)
        {
            this.LogVerbose(consumer, logMessage.Message);
        }

        private void OnError(IConsumer<string, byte[]> consumer, Error error)
        {
            this.LogError(consumer, $"ERROR: {error.Reason}");
        }

        private void OnStatistics(IConsumer<string, byte[]> consumer, string statistics)
        {
            this.LogVerbose(consumer, $"STATISTICS: {statistics}");
        }

        private void OnCommitted(IConsumer<string, byte[]> consumer, CommittedOffsets committedOffsets)
        {
            var logText = new StringBuilder();
            logText.Append("[COMMITED OFFSETS] ");

            if (committedOffsets == null)
            {
                logText.AppendLine("\tnone");
            }
            else
            {
                var offsetsText = string.Join(
                    "\t",
                    committedOffsets.Offsets?.Select(o => $"topic={o.Topic},offset={o.Offset.Value},special={o.Offset.IsSpecial}"));

                logText.AppendLine($"error={committedOffsets.Error?.Code},{offsetsText}");
            }

            this.LogVerbose(consumer, logText.ToString());
        }

        private void OnPartitionsRevoked(IConsumer<string, byte[]> consumer, List<TopicPartitionOffset> topicPartitionOffsets)
        {
            var logText = new StringBuilder();
            logText.Append("[PARTITIONS WERE REVOKED] ");

            if (topicPartitionOffsets?.Any() == true)
            {
                logText.AppendLine(
                    string.Join("\t", topicPartitionOffsets.Select(tpo => $"topic={tpo.Topic},partition={tpo.Partition},offset={tpo.Offset}")));
            }
            else
            {
                logText.AppendLine("\tnone");
            }

            this.LogVerbose(consumer, logText.ToString());
        }

        private void OnPartitionsAssigned(IConsumer<string, byte[]> consumer, List<TopicPartition> topicPartitions)
        {
            var logText = new StringBuilder();
            logText.Append("[PARTITIONS WERE ASSIGNED] ");

            if (topicPartitions?.Any() == true)
            {
                logText.AppendLine(
                    string.Join("\t", topicPartitions.Select(tp => $"topic={tp.Topic},partition={tp.Partition}")));
            }
            else
            {
                logText.AppendLine("\tnone");
            }

            this.LogVerbose(consumer, logText.ToString());
        }

        private void LogVerbose(IConsumer<string, byte[]> consumer, string message)
        {
            //this.log.Verbose(CreateConsumerLogPrefix(consumer) + message);
        }

        private void LogError(IConsumer<string, byte[]> consumer, string message)
        {
            //this.log.Error(CreateConsumerLogPrefix(consumer) + message);
        }

        private static string CreateConsumerLogPrefix(IConsumer<string, byte[]> consumer)
        {
            var subscriptionText = consumer.Subscription == null ? string.Empty : string.Join(", ", consumer.Subscription);
            return $"[ConsumerName: {consumer.Name}, Subscriptions: {subscriptionText}] ";
        }
    }
}
