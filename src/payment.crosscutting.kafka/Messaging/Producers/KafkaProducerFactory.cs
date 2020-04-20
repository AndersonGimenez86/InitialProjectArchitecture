namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Producers
{
    using System;
    using System.Collections.Generic;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Compression;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Serializers;
    using Confluent.Kafka;

    public class KafkaProducerFactory : IDisposable
    {
        private readonly List<IProducer<string, byte[]>> producers = new List<IProducer<string, byte[]>>();

        public KafkaProducerFactory()
        {
        }

        public IProducer<string, byte[]> CreateProducer(ClusterSettings clusterSettings, TopicProducerSettings topicProducerSettings)
        {
            if (topicProducerSettings == null)
            {
                throw new ArgumentNullException(nameof(topicProducerSettings));
            }

            if (!topicProducerSettings.Enabled)
            {
                return null;
            }

            var config = clusterSettings.ToClientConfig<ProducerConfig>(c =>
            {
                c.Acks = (Acks?)topicProducerSettings.Acks;
            });

            var builder = new ProducerBuilder<string, byte[]>(config)
                .SetKeySerializer(Utf8Serializer.Instance);

            if (CompressionHandlerFactory.ResolveCompressionHandler(topicProducerSettings.MessageCompressionType, out var compressionHandler))
            {
                builder.SetValueSerializer(compressionHandler);
            }

            var producer = builder.Build();

            this.producers.Add(producer);

            return producer;
        }

        public void Dispose()
        {
            foreach (var producer in this.producers)
            {
                try
                {
                    producer.Dispose();
                }
                catch
                {
                    // Don't care about this exception
                }
            }
        }
    }
}
