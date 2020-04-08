namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config
{
    using Confluent.Kafka;

    public class ClusterSettings
    {
        public string Server { get; set; }
        public bool EnableAuthentication { get; set; }
        public string SslCertificateLocation { get; set; }
        public string Username { get; set; }
        public string Secret { get; set; }
        public SaslMechanism? SaslMechanism { get; set; }
        public SecurityProtocol? SecurityProtocol { get; set; }
    }
}
