namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class SectionNames
    {
        public const string ApplicationIdentitySection = "Identity";
        public const string AuthSection = "Auth";
        public const string EndpointsSection = "Endpoints";
        public const string EnvironmentSection = "Environment";
        public const string KafkaSettingsSection = "Kafka";
        public const string LoggingSection = "Logging";
        public const string DataBaseSection = "EventStore";
    }
}
