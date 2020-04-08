using System.Diagnostics.CodeAnalysis;

namespace AG.PaymentApp.infrastructure.crosscutting.Environment
{
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
