namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KafkaConfiguration : IKafkaConfiguration
    {
        public string Environment { get; set; }
        public Dictionary<string, ClusterSettings> Clusters { get; set; } = new Dictionary<string, ClusterSettings>();
        public Dictionary<string, TopicConsumerConfiguration> Consumers { get; set; } = new Dictionary<string, TopicConsumerConfiguration>();
        public Dictionary<string, TopicProducerConfiguration> Producers { get; set; } = new Dictionary<string, TopicProducerConfiguration>();

        public bool IsProducerEnabled(string producerName)
        {
            return this.GetTopicProducerSettings(producerName)?.Enabled == true;
        }

        public bool IsConsumerEnabled(string consumerName)
        {
            return this.GetTopicConsumerSettings(consumerName)?.Enabled == true;
        }

        public TopicConsumerConfiguration GetTopicConsumerSettings(string consumerName)
        {
            if (this.Consumers?.ContainsKey(consumerName) != true)
            {
                return null;
            }

            return this.Consumers[consumerName];
        }

        public TopicProducerConfiguration GetTopicProducerSettings(string producerName)
        {
            if (this.Producers?.ContainsKey(producerName) != true)
            {
                return null;
            }

            return this.Producers[producerName];
        }

        public IEnumerable<string> GetServers()
        {
            return this.Clusters?.Select(c => c.Value.Server)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .SelectMany(s => s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                .Select(s => s.Trim())
                .Distinct()
                .ToArray()
                ?? Enumerable.Empty<string>();
        }

        public ClusterSettings GetClusterSettings(string cluster)
        {
            if (this.Clusters?.ContainsKey(cluster) != true)
            {
                return null;
            }

            return this.Clusters[cluster];
        }
    }
}
