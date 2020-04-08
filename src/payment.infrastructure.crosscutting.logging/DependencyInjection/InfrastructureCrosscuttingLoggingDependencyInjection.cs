namespace AG.PaymentApp.infrastructure.crosscutting.logging.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.infrastructure.crosscutting.logging.Interface;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfrastructureCrosscuttingLoggingDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupInfrastructureCrosscuttingLoggingDependencyInjection(this IServiceCollection services)
        {
            return services.AddSingleton<ILogger, Logger>();
        }
    }
}