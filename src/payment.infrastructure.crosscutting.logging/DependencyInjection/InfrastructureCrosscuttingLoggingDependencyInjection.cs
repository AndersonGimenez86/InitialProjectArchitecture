namespace AG.PaymentApp.Infrastructure.Crosscutting.Logging.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Infrastructure.Crosscutting.Logging.Interface;
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