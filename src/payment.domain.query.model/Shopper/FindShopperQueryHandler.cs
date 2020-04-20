namespace AG.PaymentApp.Domain.Query.Shoppers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.application.services.Adapter;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Interface;

    public class FindShopperQueryHandler : IFindShopperQueryHandler
    {
        private readonly IFindShopperRepository repository;
        private readonly IAdaptMongoEntityToEntity<ShopperMongo, Shopper> shopperAdapter;
        private readonly IMapper typeMapper;

        public FindShopperQueryHandler(
            IFindShopperRepository repository,
            IAdaptMongoEntityToEntity<ShopperMongo, Shopper> shopperAdapter,
            IMapper typeMapper)
        {
            this.repository = repository;
            this.shopperAdapter = shopperAdapter;
            this.typeMapper = typeMapper;
        }

        public async Task<Shopper> GetAsync(FindShopperQuery query)
        {
            var shopperMongo = await this.repository.GetAsync(query.ShopperID);
            return this.shopperAdapter.Adapt(shopperMongo, typeMapper);
        }

        public async Task<IEnumerable<Shopper>> GetShoppersByGender(FindShopperQuery query)
        {
            var shoppersMongo = await this.repository.GetShoppersByGenderAsync(query.Gender);
            return this.shopperAdapter.Adapt(shoppersMongo, typeMapper);

        }

        public async Task<IEnumerable<Shopper>> GetAllAsync(FindShopperQuery query)
        {
            var shoppersMongo = await this.repository.GetAllAsync(query);
            return this.shopperAdapter.Adapt(shoppersMongo, typeMapper);
        }
    }
}