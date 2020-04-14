namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Producers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.Kafka.Producers;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Serialization;
    using Confluent.Kafka;

    public class TopicProducer<TMessage> : ITopicProducer<TMessage>
        where TMessage : Event
    {
        private static readonly Encoding HeaderSerializer = Encoding.UTF8;

        private readonly IMessageSerializer<TMessage> messageSerializer;
        private readonly string topicName;
        private readonly string compressionType;
        private readonly IProducer<string, byte[]> producer;

        public TopicProducer(
            IMessageSerializer<TMessage> messageSerializer,
            string name,
            string topicName,
            string compressionType,
            IProducer<string, byte[]> producer)
        {
            this.messageSerializer = messageSerializer;
            this.Name = name;
            this.topicName = topicName;
            this.compressionType = compressionType;
            this.producer = producer;
        }

        public string Name { get; protected set; }

        public async Task<DeliveryMessageReport> ProduceAsync(TMessage message)
        {
            var messageDateTime = DateTime.UtcNow;
            var deliveryReport = new DeliveryMessageReport(this.topicName, messageDateTime);

            try
            {
                if (message == null)
                {
                    throw new ArgumentNullException(nameof(message));
                }

                var messageContent = this.messageSerializer.Serialize(message);

                var kafkaMessage = this.CreateKafkaMessage(messageDateTime, Guid.NewGuid().ToString(), message, messageContent);

                deliveryReport.UpdateMessage(kafkaMessage.Key, GetHeadersContent(kafkaMessage.Headers));

                var result = await this.producer.ProduceAsync(this.topicName, kafkaMessage);

                deliveryReport.UpdateSuccess(result.Partition, result.Offset);
            }
            catch (Exception ex)
            {
                deliveryReport.UpdateFailure(ex);
            }

            return deliveryReport;
        }

        private Message<string, byte[]> CreateKafkaMessage(DateTime messageDateTime, string key, TMessage message, byte[] messageContent)
        {
            return new Message<string, byte[]>
            {
                Headers = this.CreateHeaders(message, messageDateTime),
                Key = key,
                Timestamp = new Timestamp(messageDateTime, TimestampType.CreateTime),
                Value = messageContent
            };
        }

        private Headers CreateHeaders(TMessage message, DateTime dateTime)
        {
            const string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK";
            var t = message.GetType();

            var headersDict = new Dictionary<string, string>
            {
                ["Type"] = $"{t.FullName}, {t.Assembly.GetName().Name}",
                ["X-AG-MessageId"] = Guid.NewGuid().ToString(),
                ["X-AG-Timestamp"] = dateTime.ToString(DateTimeFormat),
                ["X-AG-Serialization"] = this.messageSerializer.Name,
                ["X-AG-Compression"] = this.compressionType,
                ["X-AG-ContractType"] = t.FullName + ", " + t.Assembly.GetName().Name
            };

            var headers = new Headers();
            foreach (var kvp in headersDict)
            {
                headers.Add(kvp.Key, HeaderSerializer.GetBytes(kvp.Value));
            }

            return headers;
        }

        private static IDictionary<string, string> GetHeadersContent(Headers headers)
        {
            return headers.ToDictionary(h => h.Key, h => HeaderSerializer.GetString(h.GetValueBytes()));
        }
    }
}
