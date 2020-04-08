namespace AG.PaymentApp.Domain.queries.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.Query.Merchants;

    public interface IFindMerchantEventRepository
    {
        Task<MerchantMongo> GetAsync(FindMerchantQuery findMerchantQuery);
        Task<IEnumerable<MerchantMongo>> GetMerchantsByCountry(string country);
        Task<IEnumerable<MerchantMongo>> GetAllAsync(FindMerchantQuery findMerchantQuery);
    }
}
