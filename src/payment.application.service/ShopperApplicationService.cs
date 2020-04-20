namespace AG.PaymentApp.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Services.Adapter.Interface;
    using AG.PaymentApp.Application.Services.DTO.Shoppers;
    using AG.PaymentApp.Application.Services.Interface;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Shoppers;
    using AutoMapper;

    public class ShopperApplicationService : IShopperApplicationService
    {
        private readonly IFindShopperQueryHandler findShopperQueryHandler;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToViewModel<Shopper, ShopperViewModel> shopperAdapter;

        public ShopperApplicationService(
            IFindShopperQueryHandler findShopperQueryHandler,
            IMapper typeMapper,
            IAdaptEntityToViewModel<Shopper, ShopperViewModel> shopperAdapter
            )
        {
            this.findShopperQueryHandler = findShopperQueryHandler;
            this.typeMapper = typeMapper;
            this.shopperAdapter = shopperAdapter;
        }

        public async Task CreateAsync(ShopperViewModel shopperDTO)
        {
            var shopper = this.typeMapper.Map<Shopper>(shopperDTO);
            shopper.Id = shopper.Id != Guid.Empty ? shopper.Id : Guid.NewGuid();
            shopper.DateCreated = DateTime.Now;

            shopper.SetAddress(shopper.Address);

            //await shopperCommand.ExecuteAsync(shopper);
        }

        public async Task<ShopperViewModel> GetAsync(Guid shopperID)
        {
            var findShopperQuery = new FindShopperQuery(shopperID, Gender.None);

            var shopper = await this.findShopperQueryHandler.GetAsync(findShopperQuery);

            return shopperAdapter.Adapt(shopper, typeMapper);
        }

        public async Task<IEnumerable<ShopperViewModel>> GetAllAsync()
        {
            var findShopperQuery = new FindShopperQuery(Guid.Empty, Gender.None);

            var shoppers = await this.findShopperQueryHandler.GetAllAsync(findShopperQuery);

            return shopperAdapter.Adapt(shoppers, typeMapper);
        }

        public async Task<IEnumerable<ShopperViewModel>> GetShoppersByGender(Gender gender)
        {
            var findShopperQuery = new FindShopperQuery(Guid.Empty, gender);

            var shoppers = await this.findShopperQueryHandler.GetShoppersByGender(findShopperQuery);

            return shopperAdapter.Adapt(shoppers, typeMapper);
        }
    }
}