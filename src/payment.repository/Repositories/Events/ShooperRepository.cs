namespace AG.PaymentApp.repository.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Shoppers;
    using AG.PaymentApp.repository.commands.Interface;
    using AG.PaymentApp.repository.Filters;
    using AG.PaymentApp.repository.Interface;
    using MongoDB.Driver;

    public class ShopperRepository : IShopperRepository, IFindShopperEventRepository
    {
        private readonly IEventShopperRepositoryStartup eventShopperRepositoryStartup;
        private readonly IMongoCollection<ShopperMongo> shopperEvents;

        public ShopperRepository(IEventShopperRepositoryStartup eventShopperRepositoryStartup)
        {
            this.eventShopperRepositoryStartup = eventShopperRepositoryStartup;
            this.shopperEvents = this.GetShopperCollection();
        }
        public async Task SaveAsync(ShopperDataCommand shopperDataCommand)
        {
            await this.shopperEvents.InsertOneAsync(shopperDataCommand.ShopperMongo);
        }

        public async Task<ShopperMongo> GetAsync(Guid shopperID)
        {
            var findShopperQuery = new FindShopperQuery(shopperID, Gender.None);
            return (await GetAllAsync(findShopperQuery)).FirstOrDefault<ShopperMongo>();
        }

        public async Task<IEnumerable<ShopperMongo>> GetAllAsync(FindShopperQuery findShopperQuery)
        {
            var filters = EventFiltersDefinition<ShopperMongo>.ApplyShooperIDFilter(findShopperQuery.ShopperID);

            if (findShopperQuery.Gender != Gender.None)
            {
                filters = Builders<ShopperMongo>.Filter.Eq(x => x.Gender, findShopperQuery.Gender);
            }

            var options = new FindOptions<ShopperMongo>
            {
                Sort = Builders<ShopperMongo>.Sort.Descending(p => p.DateCreated)
            };

            var shoppers = await this.shopperEvents
                .FindAsync(filters, options)
                .Result.ToListAsync()
                .ConfigureAwait(false);

            return shoppers;
        }
        public async Task<IEnumerable<ShopperMongo>> GetShoppersByGenderAsync(Gender gender)
        {
            var findShopperQuery = new FindShopperQuery(Guid.Empty, gender);
            return await GetAllAsync(findShopperQuery);
        }
        private IMongoCollection<ShopperMongo> GetShopperCollection()
        {
            return this.eventShopperRepositoryStartup.GetMongoCollection();
        }
    }
}
