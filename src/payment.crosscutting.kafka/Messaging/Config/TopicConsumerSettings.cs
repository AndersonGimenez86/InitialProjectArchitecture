namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config
{
    public class TopicConsumerSettings
    {
        public string Cluster { get; set; }
        public string TopicName { get; set; }
        public string GroupId { get; set; }
        public string MessageCompressionType { get; set; }
        public AutoOffsetResetType AutoOffsetReset { get; set; }
        public bool Enabled { get; set; }
    }
}
