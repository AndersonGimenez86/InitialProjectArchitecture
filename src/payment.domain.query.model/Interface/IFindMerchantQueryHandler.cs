namespace AG.PaymentApp.Domain.Query.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Query.Merchants;

    public interface IFindMerchantQueryHandler : IQueryHandler<FindMerchantQuery, Merchant>
    {
        Task<IEnumerable<Merchant>> GetMerchantsByCountry(FindMerchantQuery query);
        Task<IEnumerable<Merchant>> GetAllAsync(FindMerchantQuery query);

    }
}
