namespace AG.PaymentApp.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Shoppers;
    using AG.PaymentApp.Data.Filters;
    using AG.PaymentApp.Data.Interface;
    using AutoMapper;
    using MongoDB.Driver;

    public class ShopperRepository : IShopperRepository, IFindShopperRepository
    {
        private readonly IShopperRepositoryStartup eventShopperRepositoryStartup;
        private readonly IMongoCollection<ShopperMongo> shopperRepository;
        private readonly IMapper typeMapper;

        public ShopperRepository(IShopperRepositoryStartup eventShopperRepositoryStartup, IMapper typeMapper)
        {
            this.eventShopperRepositoryStartup = eventShopperRepositoryStartup;
            this.typeMapper = typeMapper;
            this.shopperRepository = this.GetShopperCollection();
        }
        public async Task SaveAsync(Shopper shopper)
        {
            var shopperMongo = this.typeMapper.Map<ShopperMongo>(shopper);
            await this.shopperRepository.InsertOneAsync(shopperMongo);
        }

        public async Task<Shopper> GetAsync(Guid shopperID)
        {
            var findShopperQuery = new FindShopperQuery(shopperID, Gender.None);
            return (await GetAllAsync(findShopperQuery)).FirstOrDefault<Shopper>();
        }
        public async Task<IEnumerable<Shopper>> GetShoppersByGenderAsync(Gender gender)
        {
            var findShopperQuery = new FindShopperQuery(Guid.Empty, gender);
            return await GetAllAsync(findShopperQuery);
        }
        public async Task<IEnumerable<Shopper>> GetAllAsync(FindShopperQuery findShopperQuery)
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

            var shoppers = await this.shopperRepository
                .FindAsync(filters, options)
                .Result.ToListAsync()
                .ConfigureAwait(false);

            return this.typeMapper.Map<IEnumerable<Shopper>>(shoppers);
        }

        private IMongoCollection<ShopperMongo> GetShopperCollection()
        {
            return this.eventShopperRepositoryStartup.GetMongoCollection();
        }

        public Task UpdateAsync(Shopper entity)
        {
            throw new NotImplementedException();
        }
    }
}
