namespace AG.PaymentApp.Repository.DependecyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Events.Interface;
    using AG.PaymentApp.Domain.Interface;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Repository.Interface;
    using AG.PaymentApp.Repository.Repositories;
    using AG.PaymentApp.Repository.Startup;
    using Microsoft.Extensions.DependencyInjection;
    using Payment.Data.EventSourcing;

    public static class RepositoryDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupRepository(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IPaymentRepositoryStartup, EventPaymentRepositoryStartup>()
                    .AddSingleton<IMerchantRepositoryStartup, EventMerchantRepositoryStartup>()
                    .AddSingleton<IShopperRepositoryStartup, EventShopperRepositoryStartup>()
                    .AddSingleton<IMongoRepository, MongoRepository>()
                    .AddSingleton<IMerchantRepository, MerchantRepository>()
                    .AddSingleton<IFindMerchantRepository, MerchantRepository>()
                    .AddSingleton<IPaymentRepository, PaymentRepository>()
                    .AddSingleton<IFindPaymentRepository, PaymentRepository>()
                    .AddSingleton<IShopperRepository, ShopperRepository>()
                    .AddSingleton<IFindShopperRepository, ShopperRepository>()
                    .AddScoped<IEventStore, SqlEventStore>();
        }
    }
}