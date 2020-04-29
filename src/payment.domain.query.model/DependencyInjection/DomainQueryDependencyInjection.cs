namespace AG.PaymentApp.Domain.Query.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Application.Services.Adapter;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using Microsoft.Extensions.DependencyInjection;
    public static class DomainQueryDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainQuery(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IAdaptMongoEntityToEntity<PaymentMongo, Payment>, AdaptMongoEntityToEntity<PaymentMongo, Payment>>()
                    .AddSingleton<IAdaptMongoEntityToEntity<MerchantMongo, Merchant>, AdaptMongoEntityToEntity<MerchantMongo, Merchant>>()
                    .AddSingleton<IAdaptMongoEntityToEntity<ShopperMongo, Shopper>, AdaptMongoEntityToEntity<ShopperMongo, Shopper>>();
        }
    }
}
