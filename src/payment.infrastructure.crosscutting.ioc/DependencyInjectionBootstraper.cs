namespace AG.PaymentApp.infrastructure.crosscutting.IoC
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AutoMapper;
    using AG.PaymentApp.application.messaging;
    using AG.PaymentApp.application.messaging.DependencyInjection;
    using AG.PaymentApp.application.services.DependencyInjection;
    using AG.PaymentApp.Domain.commands.DependencyInjection;
    using AG.PaymentApp.Domain.Query.DependencyInjection;
    using AG.PaymentApp.Domain.Services.DependencyInjection;
    using AG.PaymentApp.infrastructure.crosscutting.Environment;
    using AG.PaymentApp.infrastructure.crosscutting.IoC.Extensions;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config;
    using AG.PaymentApp.infrastructure.crosscutting.logging.DependencyInjection;
    using AG.PaymentApp.repository.DependecyInjection;
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
                .SetupDomainServices()
                .SetupMessaging()
                .SetupConsumers(kafkaSettingsSection)
                .SetupDomainCommands()
                .SetupDomainQuery()
                .SetupRepository()
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
