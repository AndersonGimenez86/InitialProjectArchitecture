using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace AG.PaymentApp.crosscutting.kafka
{
    public class KafkaTracer<TKey, TValue> : IProducer<TKey, TValue>
    {
        public Handle Handle => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public int AddBrokers(string brokers)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Flush(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public void Flush(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public int Poll(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public void Produce(string topic, Message<TKey, TValue> message, Action<DeliveryReport<TKey, TValue>> deliveryHandler = null)
        {
            throw new NotImplementedException();
        }

        public void Produce(TopicPartition topicPartition, Message<TKey, TValue> message, Action<DeliveryReport<TKey, TValue>> deliveryHandler = null)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryResult<TKey, TValue>> ProduceAsync(string topic, Message<TKey, TValue> message)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryResult<TKey, TValue>> ProduceAsync(TopicPartition topicPartition, Message<TKey, TValue> message)
        {
            throw new NotImplementedException();
        }
    }
}
