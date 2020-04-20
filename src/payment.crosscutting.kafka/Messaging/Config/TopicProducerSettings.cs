namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config
{
    public class TopicProducerSettings
    {
        public string Cluster { get; set; }
        public string TopicName { get; set; }
        public AcksTypes? Acks { get; set; }
        public string MessageCompressionType { get; set; }
        public int RetryBackoffMs { get; set; }
        public bool Enabled { get; set; }
    }
}
