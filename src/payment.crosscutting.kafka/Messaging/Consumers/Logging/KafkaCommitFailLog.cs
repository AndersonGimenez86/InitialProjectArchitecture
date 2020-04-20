namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Logging
{
    using System;
    using AG.PaymentApp.Infrastructure.Crosscutting.Logging;

    internal class KafkaCommitFailLog : LogTemplate<KafkaCommitFailLogData>
    {
        public const string MessageText = "Failed to commit message";

        public KafkaCommitFailLog(string topicName, double retryInSeconds, int retryCount, Exception kafkaException)
        {
            this.Data = new KafkaCommitFailLogData(topicName, retryInSeconds, retryCount, kafkaException);
        }

        public override LogLevel LogLevel => LogLevel.Error;

        public override string Message => MessageText;
    }
}