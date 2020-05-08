namespace AG.PaymentApp.Application.Services.ExternalClient.DependencyInjection
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AG.Payment.Application.Services.ExternalClient;
    using AG.Payment.Application.Services.ExternalClient.Interface;
    using AG.Payment.Infrastructure.Crosscutting.Settings;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationServicesExternalClientDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupApplicationServicesExternalClient(
            this IServiceCollection services,
            IConfiguration configurationSection)
        {
            var endPointCollectionSettings = configurationSection.Get<EndPointCollectionConfiguration>();

            foreach (var endpoint in endPointCollectionSettings.EndPointSettings)
            {
                services.AddHttpClient(endpoint.Name, c => c.BaseAddress = new Uri(endpoint.BaseAddress));
            }

            return services
                .AddScoped<IClient, Client>();
        }
    }
}
