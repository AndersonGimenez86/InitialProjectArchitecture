namespace AG.PaymentApp.Infrastructure.Crosscutting.IoC
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Application.Messaging;
    using AG.PaymentApp.Application.Messaging.DependencyInjection;
    using AG.PaymentApp.Application.Services.DependencyInjection;
    using AG.PaymentApp.Crosscutting.Bus.DependencyInjection;
    using AG.PaymentApp.Data.DependecyInjection;
    using AG.PaymentApp.Domain.Commands.DependencyInjection;
    using AG.PaymentApp.Domain.Query.DependencyInjection;
    using AG.PaymentApp.Infrastructure.Crosscutting;
    using AG.PaymentApp.Infrastructure.Crosscutting.IoC.Extensions;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config;
    using AG.PaymentApp.Infrastructure.Crosscutting.Logging.DependencyInjection;
    using AG.PaymentApp.Infrastructure.Crosscutting.Settings;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Options;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionBootstraper
    {
        public static void InitializeAppSettings(IServiceCollection services, IConfiguration configuration)
        {
            var loggingConfiguration = configuration.GetSection(SectionDefinitons.LoggingSection);
            SetupGlobalLogging(services, loggingConfiguration);

            services.TryAddSingleton<IEnvironmentConfiguration>(sp =>
                sp.GetRequiredService<IOptions<EnvironmentConfiguration>>().Value);

            services.TryAddSingleton<IIdentityConfiguration>(sp =>
               sp.GetRequiredService<IOptions<IdentityConfiguration>>().Value);

            services.TryAddSingleton<IDataBaseConfiguration>(sp =>
               sp.GetRequiredService<IOptions<DataBaseConfiguration>>().Value);

            services.TryAddSingleton<IKafkaConfiguration>(sp =>
               sp.GetRequiredService<IOptions<KafkaConfiguration>>().Value);

            services.TryAddSingleton<IEndPointCollectionConfiguration>(sp =>
               sp.GetRequiredService<IOptions<EndPointCollectionConfiguration>>().Value);
        }

        public static void InitializeServices(IServiceProvider applicationServices)
        {
            applicationServices.StartTopicConsumptionService();
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var kafkaSettingsSection = configuration.GetSection(SectionNames.KafkaSettingsSection);

            services.SetupApplicationServices(kafkaSettingsSection)
                .SetupInfrastructureCrosscuttingLoggingDependencyInjection()
                .SetupApplicationMessaging()
                .SetupMessaging()
                .SetupConsumers(kafkaSettingsSection)
                .SetupDomainEvents()
                .SetupDomainCommands()
                .SetupDomainQuery()
                .SetupRepository()
                .SetupCrosscuttingBus()
                .AddAutoMapper(AppDomain.CurrentDomain.GetUserAssemblies());

            services.AddSingleton<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
        }

        private static void SetupGlobalLogging(IServiceCollection services, IConfigurationSection loggingConfiguration)
        {
            //var loggingSettings = loggingConfiguration.Get<LoggingSettings>();
            //var log = GlobalLogInitializer.SetupLogger(loggingSettings);
            //services.AddSingleton(_ => log);
        }
    }
}
