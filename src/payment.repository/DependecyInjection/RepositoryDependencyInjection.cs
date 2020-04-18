namespace AG.PaymentApp.repository.DependecyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.repository.commands.Interface;
    using AG.PaymentApp.repository.Interface;
    using AG.PaymentApp.repository.Repositories;
    using AG.PaymentApp.repository.Startup;
    using Microsoft.Extensions.DependencyInjection;


    public static class RepositoryDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupRepository(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IMongoRepository, MongoRepository>()
                    .AddSingleton<IMerchantRepository, MerchantRepository>()
                    .AddSingleton<IFindMerchantEventRepository, MerchantRepository>()
                    .AddSingleton<IPaymentEventRepository, PaymentRepository>()
                    .AddSingleton<IFindPaymentEventRepository, PaymentRepository>()
                    .AddSingleton<IShopperRepository, ShopperRepository>()
                    .AddSingleton<IFindShopperEventRepository, ShopperRepository>()
                    .AddSingleton<IEventPaymentRepositoryStartup, EventPaymentRepositoryStartup>()
                    .AddSingleton<IEventMerchantRepositoryStartup, EventMerchantRepositoryStartup>()
                    .AddSingleton<IEventShopperRepositoryStartup, EventShopperRepositoryStartup>();

        }
    }
}