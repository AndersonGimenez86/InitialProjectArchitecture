namespace AG.PaymentApp.Crosscutting.Bus.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.Payment.Domain.Core.Bus;
    using AG.Payment.Domain.Events;
    using AG.Payment.Infrastructure.Crosscutting.Bus;
    using Microsoft.Extensions.DependencyInjection;

    public static class CrosscuttingBusDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupCrosscuttingBus(this IServiceCollection services)
        {
            return services
                .AddScoped<IMediatorHandler, InMemoryBus<PaymentRegisteredEvent>>();
        }
    }
}
