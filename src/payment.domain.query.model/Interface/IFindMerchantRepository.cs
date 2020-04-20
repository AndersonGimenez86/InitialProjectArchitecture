namespace AG.PaymentApp.Domain.queries.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Query.Merchants;

    public interface IFindMerchantRepository
    {
        Task<Merchant> GetAsync(FindMerchantQuery findMerchantQuery);
        Task<IEnumerable<Merchant>> GetMerchantsByCountry(string country);
        Task<IEnumerable<Merchant>> GetAllAsync(FindMerchantQuery findMerchantQuery);
    }
}
