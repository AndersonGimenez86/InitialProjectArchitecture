namespace AG.PaymentApp.application.messaging.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.DependencyInjection;
    public static class ApplicationMessagingDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupApplicationMessaging(this IServiceCollection services)
        {
            //TODO: review
            //return services
            //        .AddTransient<IEventCommand, CreatePaymentEvent>()
            //        .AddTransient<IEventCommand, CreateTransactionEvent>();
            return services;
        }
    }
}
