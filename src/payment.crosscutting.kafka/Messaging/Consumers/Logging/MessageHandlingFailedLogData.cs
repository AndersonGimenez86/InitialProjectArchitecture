namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Logging
{
    using System;

    internal class MessageHandlingFailedLogData
    {
        public MessageHandlingFailedLogData(string topic, int partition, long offset, bool isPartitionEOF, string key, Exception exception)
        {
            this.Topic = topic;
            this.Partition = partition;
            this.Offset = offset;
            this.IsPartitionEOF = isPartitionEOF;
            this.Key = key;
            this.Exception = exception;
        }

        public string Topic { get; }
        public int Partition { get; }
        public long Offset { get; }
        public bool IsPartitionEOF { get; }
        public string Key { get; }
        public Exception Exception { get; }
    }
}
