namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config
{
    using System;
    using Confluent.Kafka;

    internal static class ClusterSettingsExtensions
    {
        public static TConfig ToClientConfig<TConfig>(this ClusterSettings clusterSettings, Action<TConfig> setup = null)
            where TConfig : ClientConfig, new()
        {
            var config = new TConfig
            {
                BootstrapServers = clusterSettings.Server,
                SslCaLocation = clusterSettings.SslCertificateLocation
            };

            if (clusterSettings.EnableAuthentication)
            {
                config.SaslMechanism = (Confluent.Kafka.SaslMechanism?)clusterSettings.SaslMechanism;
                config.SecurityProtocol = (Confluent.Kafka.SecurityProtocol?)clusterSettings.SecurityProtocol;

                config.SaslUsername = clusterSettings.Username;
                config.SaslPassword = clusterSettings.Secret;
            }

            setup?.Invoke(config);

            return config;
        }
    }
}
