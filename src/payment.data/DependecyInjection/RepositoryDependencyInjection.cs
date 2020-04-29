namespace AG.PaymentApp.Data.DependecyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Data.Interface;
    using AG.PaymentApp.Data.Repositories;
    using AG.PaymentApp.Data.Startup;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Interface;
    using AG.PaymentApp.Domain.queries.Interface;
    using Microsoft.Extensions.DependencyInjection;

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
                    .AddSingleton<IFindShopperRepository, ShopperRepository>();
        }
    }
}