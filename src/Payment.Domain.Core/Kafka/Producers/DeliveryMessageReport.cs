namespace AG.PaymentApp.Domain.Core.Kafka.Producers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using AG.PaymentApp.Domain.Core.Events;
    using MediatR;

    public class DeliveryMessageReport : Message, INotification
    {
        public DeliveryMessageReport(string topic, DateTime dateTime)
        {
            this.Topic = topic;
            this.DateTime = dateTime;
        }

        public string Topic { get; }
        public DateTime DateTime { get; }

        public string Key { get; private set; }
        public IReadOnlyDictionary<string, string> Headers { get; private set; }

        public int Partition { get; private set; }
        public long Offset { get; private set; }
        public Exception Exception { get; private set; }

        public bool Success => this.Exception == null;

        public void UpdateMessage(string key, IDictionary<string, string> headers)
        {
            this.Key = key;
            this.Headers = new ReadOnlyDictionary<string, string>(headers);
        }

        public void UpdateSuccess(int partition, long offset)
        {
            this.Partition = partition;
            this.Offset = offset;
        }

        public void UpdateFailure(Exception exception)
        {
            this.Exception = exception;
        }
    }
}
