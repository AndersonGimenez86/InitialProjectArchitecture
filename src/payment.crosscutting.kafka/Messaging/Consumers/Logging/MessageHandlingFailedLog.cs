namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Logging
{
    using System;
    using AG.PaymentApp.Infrastructure.Crosscutting.Logging;

    internal class MessageHandlingFailedLog : LogTemplate<MessageHandlingFailedLogData>
    {
        public const string MessageText = "Could not handle received message.";

        public MessageHandlingFailedLog(string topic, int partition, long offset, bool isPartitionEOF, string key, Exception exception)
        {
            this.Data = new MessageHandlingFailedLogData(topic, partition, offset, isPartitionEOF, key, exception);
        }

        public override LogLevel LogLevel => LogLevel.Fatal;

        public override string Message => MessageText;
    }
}
