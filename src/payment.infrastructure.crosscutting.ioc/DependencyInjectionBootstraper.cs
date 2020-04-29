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
    using AG.PaymentApp.Infrastructure.Crosscutting.Environment;
    using AG.PaymentApp.Infrastructure.Crosscutting.IoC.Extensions;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config;
    using AG.PaymentApp.Infrastructure.Crosscutting.Logging.DependencyInjection;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionBootstraper
    {
        public static void InitializeAppSettings(IServiceCollection services, IConfiguration configuration)
        {
            var loggingConfiguration = configuration.GetSection(SectionDefinitons.LoggingSection);
            SetupGlobalLogging(services, loggingConfiguration);

            services.Configure<EnvironmentSettings>(configuration.GetSection(SectionNames.EnvironmentSection));
            services.Configure<IdentitySettings>(configuration.GetSection(SectionNames.ApplicationIdentitySection));
            services.Configure<DataBaseSettings>(configuration.GetSection(SectionNames.DataBaseSection));
            services.Configure<KafkaSettings>(configuration.GetSection(SectionNames.KafkaSettingsSection));

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
