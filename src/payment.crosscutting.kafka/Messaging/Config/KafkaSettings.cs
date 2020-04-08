namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KafkaSettings
    {
        public string Environment { get; set; }
        public Dictionary<string, ClusterSettings> Clusters { get; set; } = new Dictionary<string, ClusterSettings>();
        public Dictionary<string, TopicConsumerSettings> Consumers { get; set; } = new Dictionary<string, TopicConsumerSettings>();
        public Dictionary<string, TopicProducerSettings> Producers { get; set; } = new Dictionary<string, TopicProducerSettings>();

        public bool IsProducerEnabled(string producerName)
        {
            return this.GetTopicProducerSettings(producerName)?.Enabled == true;
        }

        public bool IsConsumerEnabled(string consumerName)
        {
            return this.GetTopicConsumerSettings(consumerName)?.Enabled == true;
        }

        public TopicConsumerSettings GetTopicConsumerSettings(string consumerName)
        {
            if (this.Consumers?.ContainsKey(consumerName) != true)
            {
                return null;
            }

            return this.Consumers[consumerName];
        }

        public TopicProducerSettings GetTopicProducerSettings(string producerName)
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
