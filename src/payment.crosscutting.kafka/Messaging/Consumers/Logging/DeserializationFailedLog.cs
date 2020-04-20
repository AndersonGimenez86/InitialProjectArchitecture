namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Logging
{
    using System;
    using AG.PaymentApp.Infrastructure.Crosscutting.Logging;

    internal class DeserializationFailedLog : LogTemplate<DeserializationFailedLogData>
    {
        public const string MessageText = "Could not deserialize the message.";

        public DeserializationFailedLog(string topic, int partition, long offset, bool isPartitionEOF, string key, Exception exception)
        {
            this.Data = new DeserializationFailedLogData(topic, partition, offset, isPartitionEOF, key, exception);
        }

        public override LogLevel LogLevel => LogLevel.Fatal;

        public override string Message => MessageText;
    }
}
