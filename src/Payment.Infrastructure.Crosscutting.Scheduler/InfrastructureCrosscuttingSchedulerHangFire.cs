namespace AG.Payment.Infrastructure.Crosscutting.Scheduler
{
    using System.Diagnostics.CodeAnalysis;
    using Hangfire;
    using Hangfire.Mongo;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfrastructureCrosscuttingSchedulerHangFire
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupHangFire(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var migrationOptions = new MongoMigrationOptions
            {
                Strategy = MongoMigrationStrategy.Drop,
                BackupStrategy = MongoBackupStrategy.Collections
            };

            services.AddHangfireServer();

            return services.AddHangfire(config =>
            {
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
                config.UseSimpleAssemblyNameTypeSerializer();
                config.UseRecommendedSerializerSettings();
                config.UseMongoStorage(configuration.GetSection("MongoDbConnectionString")
                      .GetSection("HangFireConnection").Value, new MongoStorageOptions { MigrationOptions = migrationOptions });
            });
        }
    }
}
