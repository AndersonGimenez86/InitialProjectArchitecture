namespace AG.PaymentApp.application.messaging.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.application.messaging.Events;
    using AG.PaymentApp.application.messaging.Events.Interface;
    using Microsoft.Extensions.DependencyInjection;
    public static class ApplicationMessagingDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupApplicationMessaging(this IServiceCollection services)
        {
            return services
                    .AddTransient<IEventCommand, CreatePaymentEvent>()
                    .AddTransient<IEventCommand, CreateTransactionEvent>();
        }
    }
}
