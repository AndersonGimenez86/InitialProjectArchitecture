namespace AG.PaymentApp.Application.Messaging
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using AG.PaymentApp.Application.Messaging.Handlers;
    using AG.PaymentApp.Domain.Events;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Consumers.Interface;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Serialization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    [ExcludeFromCodeCoverage]
    public static class KafkaBootstrap
    {
        public static IServiceCollection SetupConsumers(
            this IServiceCollection serviceCollection,
            IConfigurationSection configurationSection)
        {
            var kafkaSettings = configurationSection.Get<KafkaSettings>();

            serviceCollection.AddSingleton<ITopicConsumerService, TopicConsumerService>();

            if (kafkaSettings.IsConsumerEnabled("ConsumerFromBankAcquiring"))
            {
                serviceCollection
                    .AddTopicConsumer<CreateTransactionEvent>("ConsumerFromBankAcquiring");
            }

            if (kafkaSettings.IsConsumerEnabled("ConsumerAGPayment"))
            {
                serviceCollection
                    .AddTopicConsumer<CreatePaymentEvent>("ConsumerAGPayment");
            }

            serviceCollection
                    .AddSingleton<IMessageHandler<CreateTransactionEvent>, PaymentEventHandler>()
                    .AddSingleton<IMessageHandler<CreatePaymentEvent>, BankEventHandler>()
                    .AddSingleton<IMessageSerializer<CreatePaymentEvent>, JsonMessageSerializer<CreatePaymentEvent>>()
                    .AddSingleton<IMessageSerializer<CreateTransactionEvent>, JsonMessageSerializer<CreateTransactionEvent>>();

            return serviceCollection;
        }

        public static IServiceProvider StartTopicConsumptionService(this IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
        {
            var topicConsumptionService = serviceProvider.GetRequiredService<ITopicConsumerService>();

            topicConsumptionService.Start(cancellationToken);

            return serviceProvider;
        }

        //private static void SetupAdaptersDependencyInjection(this IServiceCollection services)
        //{
        //    services.AddSingleton<IEventToEventDTOAdapter<PaymentDTO, Payment>, PaymentEventToPaymentDTOAdapter>();
        //}
    }
}
