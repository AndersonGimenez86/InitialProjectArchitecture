namespace AG.PaymentApp.application.services.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.application.messaging.Events;
    using AG.PaymentApp.application.services.Adapter;
    using AG.PaymentApp.application.services.Adapter.Interface;
    using AG.PaymentApp.application.services.DTO.Merchants;
    using AG.PaymentApp.application.services.DTO.Payments;
    using AG.PaymentApp.application.services.DTO.Shoppers;
    using AG.PaymentApp.application.services.Events;
    using AG.PaymentApp.application.services.Events.Interface;
    using AG.PaymentApp.application.services.Interface;
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
                    .AddTransient<IEventCommandHandler<CreatePaymentEvent, Payment>, ProcessEventBeforePaymentCommand>()
                    .AddSingleton<IAdaptEntityToDTO<Payment, PaymentDTO>, AdaptEntityToDTO<Payment, PaymentDTO>>()
                    .AddSingleton<IAdaptEntityToDTO<Merchant, MerchantDTO>, AdaptEntityToDTO<Merchant, MerchantDTO>>()
                    .AddSingleton<IAdaptEntityToDTO<Shopper, ShopperDTO>, AdaptEntityToDTO<Shopper, ShopperDTO>>()
                    .AddSingleton<IMessageSerializer<CreatePaymentEvent>, JsonMessageSerializer<CreatePaymentEvent>>()
                    .AddSingleton<IMessageSerializer<CreateTransactionEvent>, JsonMessageSerializer<CreateTransactionEvent>>();

            //services.RegisterAllTypes<IInvoicingService>(new[] { typeof(Startup).Assembly });
        }

        //public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
        //        ServiceLifetime lifetime = ServiceLifetime.Transient)
        //{
        //    var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
        //    foreach (var type in typesFromAssemblies)
        //        services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        //}

        //    Adding CQRS command handlers

        //        var commandHandlers = typeof(Startup).Assembly.GetTypes()
        //         .Where(t => t.GetInterfaces().Any(i a => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>))
        //     );  

        //     foreach (var handler in commandHandlers)  
        //     {  
        //         services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)), handler);  
        //     }

        //Adding CQRS query handlers

        //    var queryHandlers = typeof(Startup).Assembly.GetTypes()
        //         .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))
        //     );  

        //     foreach (var handler in queryHandlers)  
        //     {  
        //         services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)), handler);  
        //     }  

        //private static void AddCommandQueryHandlers(this IServiceCollection services, Type handlerInterface)
        //{
        //    var handlers = typeof(ServiceExtensions).Assembly.GetTypes()
        //        .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
        //    );

        //    foreach (var handler in handlers)
        //    {
        //        services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
        //    }
        //}

    }
}
