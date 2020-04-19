namespace AG.PaymentApp.repository.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using AG.PaymentApp.repository.commands.Interface;
    using AG.PaymentApp.repository.Filters;
    using AG.PaymentApp.repository.Interface;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class MerchantRepository : IMerchantRepository, IFindMerchantEventRepository
    {
        private readonly IEventMerchantRepositoryStartup eventMerchantRepositoryStartup;
        private readonly IMongoCollection<MerchantMongo> merchantEvents;

        public MerchantRepository(IEventMerchantRepositoryStartup eventMerchantRepositoryStartup)
        {
            this.eventMerchantRepositoryStartup = eventMerchantRepositoryStartup;
            this.merchantEvents = this.GetMerchantCollection();
        }
        public async Task SaveAsync(MerchantCommand merchantDataCommand)
        {
            await this.merchantEvents.InsertOneAsync(merchantDataCommand.MerchantMongo);
        }

        public async Task<MerchantMongo> GetAsync(FindMerchantQuery findMerchantQuery)
        {
            return (await GetAllAsync(findMerchantQuery)).FirstOrDefault<MerchantMongo>();
        }

        public async Task<IEnumerable<MerchantMongo>> GetAllAsync(FindMerchantQuery findMerchantQuery)
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

            var merchants = await this.merchantEvents
                .FindAsync(filters, options)
                .Result.ToListAsync()
                .ConfigureAwait(false);

            return merchants;
        }
        public async Task<IEnumerable<MerchantMongo>> GetMerchantsByCountry(string country)
        {
            var findMerchantQuery = new FindMerchantQuery(Guid.Empty, country, string.Empty);
            return await GetAllAsync(findMerchantQuery);
        }
        private IMongoCollection<MerchantMongo> GetMerchantCollection()
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            return this.eventMerchantRepositoryStartup.GetMongoCollection();
        }

        public void Add(MerchantCommand obj)
        {
            throw new NotImplementedException();
        }

        public MerchantCommand GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MerchantCommand> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MerchantCommand obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
