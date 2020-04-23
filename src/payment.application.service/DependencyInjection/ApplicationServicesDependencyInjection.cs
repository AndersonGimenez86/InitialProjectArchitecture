namespace AG.PaymentApp.Application.Services.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Application.Services.Adapter;
    using AG.PaymentApp.Application.Services.Adapter.Interface;
    using AG.PaymentApp.Application.Services.DTO.Merchants;
    using AG.PaymentApp.Application.Services.DTO.Payments;
    using AG.PaymentApp.Application.Services.DTO.Shoppers;
    using AG.PaymentApp.Application.Services.Interface;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.Events;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Serialization;
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
                    .AddScoped<IPaymentApplicationService, PaymentApplicationService>()
                    .AddScoped<IMerchantApplicationService, MerchantApplicationService>()
                    .AddScoped<IShopperApplicationService, ShopperApplicationService>()
                    //.AddTransient<IEventCommandHandler<CreatePaymentEvent, Payment>, ProcessEventBeforePaymentCommand>()
                    .AddSingleton<IAdaptEntityToViewModel<Payment, PaymentViewModel>, AdaptEntityToViewModel<Payment, PaymentViewModel>>()
                    .AddSingleton<IAdaptEntityToViewModel<Merchant, MerchantViewModel>, AdaptEntityToViewModel<Merchant, MerchantViewModel>>()
                    .AddSingleton<IAdaptEntityToViewModel<Shopper, ShopperViewModel>, AdaptEntityToViewModel<Shopper, ShopperViewModel>>()
                    .AddSingleton<IMessageSerializer<CreatePaymentEvent>, JsonMessageSerializer<CreatePaymentEvent>>()
                    .AddSingleton<IMessageSerializer<CreateTransactionEvent>, JsonMessageSerializer<CreateTransactionEvent>>();

        }
    }
}
