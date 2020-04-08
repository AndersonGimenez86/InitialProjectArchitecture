namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Consumers.Logging
{
    using System;
    using AG.PaymentApp.infrastructure.crosscutting.logging;

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