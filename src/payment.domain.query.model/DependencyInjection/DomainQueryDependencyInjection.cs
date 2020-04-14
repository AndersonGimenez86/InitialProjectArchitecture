namespace AG.PaymentApp.Domain.Query.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.application.services.Adapter;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using AG.PaymentApp.Domain.Query.Payments;
    using AG.PaymentApp.Domain.Query.Shoppers;
    using Microsoft.Extensions.DependencyInjection;
    public static class DomainQueryDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainQuery(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IFindPaymentQueryHandler, FindPaymentQueryHandler>()
                    .AddSingleton<IFindMerchantQueryHandler, FindMerchantQueryHandler>()
                    .AddSingleton<IFindShopperQueryHandler, FindShopperQueryHandler>()
                    .AddSingleton<IAdaptMongoEntityToEntity<PaymentMongo, Payment>, AdaptMongoEntityToEntity<PaymentMongo, Payment>>()
                    .AddSingleton<IAdaptMongoEntityToEntity<MerchantMongo, Merchant>, AdaptMongoEntityToEntity<MerchantMongo, Merchant>>()
                    .AddSingleton<IAdaptMongoEntityToEntity<ShopperMongo, Shopper>, AdaptMongoEntityToEntity<ShopperMongo, Shopper>>();
        }
    }
}
