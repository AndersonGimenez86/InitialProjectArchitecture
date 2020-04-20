namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.crosscutting.kafka;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using AG.PaymentApp.Infrastructure.Crosscutting.kafka.Exceptions;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Interface;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Producers;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Serialization;
    using Confluent.Kafka;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupMessaging(this IServiceCollection serviceCollection)
        {
            var tracer = new KafkaTracer<string, byte[]>();

            return serviceCollection
                .AddSingleton<KafkaProducerFactory>()
                .AddSingleton<KafkaConsumerFactory>()
                .AddSingleton<IProducer<string, byte[]>>(tracer);
        }

        public static IServiceCollection AddTopicConsumer<TMessage>(this IServiceCollection serviceCollection, string consumerName)
            where TMessage : class
        {
            return serviceCollection.AddSingleton(sp => sp.CreateConsumer<TMessage>(consumerName));
        }

        public static IServiceCollection AddTopicProducer<TMessage>(this IServiceCollection serviceCollection, string producerName)
            where TMessage : Event
        {
            return serviceCollection.AddSingleton(sp => sp.CreateProducer<TMessage>(producerName));
        }

        private static ITopicProducer<TMessage> CreateProducer<TMessage>(this IServiceProvider serviceProvider, string producerName)
          where TMessage : Event
        {
            var kafkaSettings = serviceProvider.GetRequiredService<IOptions<KafkaSettings>>();
            var producerFactory = serviceProvider.GetRequiredService<KafkaProducerFactory>();

            var topicProducerSettings = kafkaSettings.Value.GetTopicProducerSettings(producerName);
            if (topicProducerSettings == null)
            {
                throw new ConfigurationException($"Topic producer settings not found. Consumer name: {producerName}");
            }

            var clusterSettings = kafkaSettings.Value.GetClusterSettings(topicProducerSettings.Cluster);
            if (clusterSettings == null)
            {
                throw new ConfigurationException($"Cluster settings not found. Cluster name: {topicProducerSettings.Cluster}");
            }

            var producer = producerFactory.CreateProducer(clusterSettings, topicProducerSettings);

            return new TopicProducer<TMessage>(
                serviceProvider.GetRequiredService<IMessageSerializer<TMessage>>(),
                producerName,
                topicProducerSettings.TopicName,
                topicProducerSettings.MessageCompressionType,
                producer);
        }

        private static ITopicPartitionConsumer CreateConsumer<TMessage>(this IServiceProvider serviceProvider, string consumerName)
            where TMessage : class
        {
            var kafkaSettings = serviceProvider.GetRequiredService<IOptions<KafkaSettings>>();
            var consumerFactory = serviceProvider.GetRequiredService<KafkaConsumerFactory>();

            var topicConsumerSettings = kafkaSettings.Value.GetTopicConsumerSettings(consumerName);
            if (topicConsumerSettings == null)
            {
                throw new ConfigurationException($"Topic consumer settings not found. Consumer name: {consumerName}");
            }

            var clusterSettings = kafkaSettings.Value.GetClusterSettings(topicConsumerSettings.Cluster);
            if (clusterSettings == null)
            {
                throw new ConfigurationException($"Cluster settings not found. Cluster name: {topicConsumerSettings.Cluster}");
            }

            var consumer = consumerFactory.CreateConsumer(clusterSettings, topicConsumerSettings);

            return new TopicPartitionConsumer<TMessage>(
               consumerName,
               topicConsumerSettings.TopicName,
               consumer,
               serviceProvider.GetRequiredService<IMessageSerializer<TMessage>>(),
               serviceProvider.GetRequiredService<IMessageHandler<TMessage>>());
        }
    }
}
