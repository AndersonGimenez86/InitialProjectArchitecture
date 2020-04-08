namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Consumers.Logging
{
    using System;

    internal class KafkaCommitFailLogData
    {
        public KafkaCommitFailLogData(
            string topicName,
            double retryInSeconds,
            int retryCount,
            Exception kafkaException)
        {
            this.TopicName = topicName;
            this.RetryInSeconds = retryInSeconds;
            this.RetryCount = retryCount;
            this.KafkaException = kafkaException;
        }

        public Exception KafkaException { get; }
        public int RetryCount { get; }
        public double RetryInSeconds { get; }
        public string TopicName { get; }
    }
}