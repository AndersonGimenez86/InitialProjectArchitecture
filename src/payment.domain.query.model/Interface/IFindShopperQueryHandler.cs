namespace AG.PaymentApp.Domain.Query.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.Query.Shoppers;

    public interface IFindShopperQueryHandler : IQueryHandler<FindShopperQuery, Shopper>
    {
        Task<IEnumerable<Shopper>> GetAllAsync(FindShopperQuery query);
        Task<IEnumerable<Shopper>> GetShoppersByGender(FindShopperQuery query);
    }
}
