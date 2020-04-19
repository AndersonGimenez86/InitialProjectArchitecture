namespace AG.PaymentApp.application.services.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.application.services.Adapter;
    using AG.PaymentApp.application.services.Adapter.Interface;
    using AG.PaymentApp.application.services.DTO.Merchants;
    using AG.PaymentApp.application.services.DTO.Payments;
    using AG.PaymentApp.application.services.DTO.Shoppers;
    using AG.PaymentApp.application.services.Interface;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Serialization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public static class ApplicationServicesDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupApplicationServices(
            this IServiceCollection services,
            IConfigurationSection configurationSection)
        {
            var kafkaSettings = configurationSection.Get<KafkaSettings>();

            if (kafkaSettings.IsProducerEnabled("ProducerBankAcquiring"))
            {
                services.AddTopicProducer<CreateTransactionEvent>("ProducerBankAcquiring");
            }

            if (kafkaSettings.IsProducerEnabled("ProducerAGPayment"))
            {
                services.AddTopicProducer<CreatePaymentEvent>("ProducerAGPayment");
            }

            return services
                    .AddTransient<IPaymentApplicationService, PaymentApplicationService>()
                    .AddTransient<IMerchantApplicationService, MerchantApplicationService>()
                    .AddTransient<IShopperApplicationService, ShopperApplicationService>()
                    //.AddTransient<IEventCommandHandler<CreatePaymentEvent, Payment>, ProcessEventBeforePaymentCommand>()
                    .AddSingleton<IAdaptEntityToViewModel<Payment, PaymentViewModel>, AdaptEntityToViewModel<Payment, PaymentViewModel>>()
                    .AddSingleton<IAdaptEntityToViewModel<Merchant, MerchantViewModel>, AdaptEntityToViewModel<Merchant, MerchantViewModel>>()
                    .AddSingleton<IAdaptEntityToViewModel<Shopper, ShopperViewModel>, AdaptEntityToViewModel<Shopper, ShopperViewModel>>()
                    .AddSingleton<IMessageSerializer<CreatePaymentEvent>, JsonMessageSerializer<CreatePaymentEvent>>()
                    .AddSingleton<IMessageSerializer<CreateTransactionEvent>, JsonMessageSerializer<CreateTransactionEvent>>();

        }
    }
}
