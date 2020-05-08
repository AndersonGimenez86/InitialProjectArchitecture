namespace AG.PaymentApp.Domain.Query.Merchants
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Services.Adapter;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Interface;
    using AutoMapper;

    public class FindMerchantQueryHandler : IFindMerchantQueryHandler
    {
        private readonly IFindMerchantRepository repository;
        private readonly IAdaptMongoEntityToEntity<MerchantMongo, Merchant> merchantAdapter;
        private readonly IMapper typeMapper;

        public FindMerchantQueryHandler(
            IFindMerchantRepository repository,
            IAdaptMongoEntityToEntity<MerchantMongo, Merchant> merchantAdapter,
            IMapper typeMapper)
        {
            this.repository = repository;
            this.merchantAdapter = merchantAdapter;
            this.typeMapper = typeMapper;
        }

        public async Task<Merchant> GetAsync(FindMerchantQuery query)
        {
            return await this.repository.GetAsync(query.MerchantID);
        }

        public async Task<IEnumerable<Merchant>> GetMerchantsByCountry(FindMerchantQuery query)
        {
            return await this.repository.GetMerchantsByCountry(query.Country);
        }

        public async Task<IEnumerable<Merchant>> GetAllAsync(FindMerchantQuery query)
        {
            return await this.repository.GetAllAsync(query);
        }
    }
}