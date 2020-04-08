namespace AG.PaymentApp.Domain.queries.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.Query.Shoppers;

    public interface IFindShopperEventRepository
    {
        Task<ShopperMongo> GetAsync(Guid merchantID);
        Task<IEnumerable<ShopperMongo>> GetShoppersByGenderAsync(Gender gender);
        Task<IEnumerable<ShopperMongo>> GetAllAsync(FindShopperQuery findMerchantQuery);
    }
}
