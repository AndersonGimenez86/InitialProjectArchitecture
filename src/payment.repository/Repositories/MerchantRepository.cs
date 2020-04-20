namespace AG.PaymentApp.Repository.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using AG.PaymentApp.Repository.Filters;
    using AG.PaymentApp.Repository.Interface;
    using AutoMapper;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class MerchantRepository : IMerchantRepository, IFindMerchantRepository
    {
        private readonly IMerchantRepositoryStartup eventMerchantRepositoryStartup;
        private readonly IMongoCollection<MerchantMongo> merchantRepository;
        private readonly IMapper typeMapper;

        public MerchantRepository(IMerchantRepositoryStartup eventMerchantRepositoryStartup,
            IMapper typeMapper)
        {
            this.eventMerchantRepositoryStartup = eventMerchantRepositoryStartup;
            this.merchantRepository = this.GetMerchantCollection();
            this.typeMapper = typeMapper;
        }
        public async Task SaveAsync(Merchant merchant)
        {
            var merchantMongo = this.typeMapper.Map<MerchantMongo>(merchant);
            await this.merchantRepository.InsertOneAsync(merchantMongo);
        }

        public async Task<Merchant> GetAsync(FindMerchantQuery findMerchantQuery)
        {
            return (await GetAllAsync(findMerchantQuery)).FirstOrDefault<Merchant>();
        }

        public async Task<IEnumerable<Merchant>> GetAllAsync(FindMerchantQuery findMerchantQuery)
        {
            var filters = EventFiltersDefinition<MerchantMongo>.ApplyMerchantIDFilter(findMerchantQuery.MerchantID);

            if (!string.IsNullOrEmpty(findMerchantQuery.Country))
            {
                filters = Builders<MerchantMongo>.Filter.Eq(x => x.Country, findMerchantQuery.Country);
            }

            if (!string.IsNullOrEmpty(findMerchantQuery.Name))
            {
                filters = Builders<MerchantMongo>.Filter.Eq(x => x.Name, findMerchantQuery.Name);
            }

            var options = new FindOptions<MerchantMongo>
            {
                Sort = Builders<MerchantMongo>.Sort.Descending(p => p.DateCreated)
            };

            var merchants = await this.merchantRepository
                .FindAsync(filters, options)
                .Result.ToListAsync()
                .ConfigureAwait(false);

            return this.typeMapper.Map<IEnumerable<Merchant>>(merchants);
        }
        public async Task<IEnumerable<Merchant>> GetMerchantsByCountry(string country)
        {
            var findMerchantQuery = new FindMerchantQuery(Guid.Empty, country, string.Empty);
            return await GetAllAsync(findMerchantQuery);
        }
        private IMongoCollection<MerchantMongo> GetMerchantCollection()
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            return this.eventMerchantRepositoryStartup.GetMongoCollection();
        }

        public Task UpdateAsync(Merchant entity)
        {
            throw new NotImplementedException();
        }
    }
}
