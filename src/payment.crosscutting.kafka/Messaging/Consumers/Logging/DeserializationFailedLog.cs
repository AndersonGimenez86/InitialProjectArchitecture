namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Consumers.Logging
{
    using System;
    using AG.PaymentApp.infrastructure.crosscutting.logging;

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
