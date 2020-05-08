namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config
{
    using System.Collections.Generic;

    public interface IKafkaConfiguration
    {
        Dictionary<string, ClusterSettings> Clusters { get; set; }
        Dictionary<string, TopicConsumerConfiguration> Consumers { get; set; }
        string Environment { get; set; }
        Dictionary<string, TopicProducerConfiguration> Producers { get; set; }

        ClusterSettings GetClusterSettings(string cluster);
        IEnumerable<string> GetServers();
        TopicConsumerConfiguration GetTopicConsumerSettings(string consumerName);
        TopicProducerConfiguration GetTopicProducerSettings(string producerName);
        bool IsConsumerEnabled(string consumerName);
        bool IsProducerEnabled(string producerName);
    }
}