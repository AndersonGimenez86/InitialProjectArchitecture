namespace AG.PaymentApp.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Services.Adapter.Interface;
    using AG.PaymentApp.Application.Services.DTO.Shoppers;
    using AG.PaymentApp.Application.Services.Interface;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Shoppers;
    using AutoMapper;

    public class ShopperApplicationService : IShopperApplicationService
    {
        private readonly IFindShopperRepository findShopperRepository;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToViewModel<Shopper, ShopperViewModel> shopperAdapter;

        public ShopperApplicationService(
            IFindShopperRepository findShopperRepository,
            IMapper typeMapper,
            IAdaptEntityToViewModel<Shopper, ShopperViewModel> shopperAdapter
            )
        {
            this.findShopperRepository = findShopperRepository;
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
            var shopper = await this.findShopperRepository.GetAsync(shopperID);
            return shopperAdapter.Adapt(shopper, typeMapper);
        }

        public async Task<IEnumerable<ShopperViewModel>> GetAllAsync()
        {
            var findShopperQuery = new FindShopperQuery(Guid.Empty, Gender.None);
            var shoppers = await this.findShopperRepository.GetAllAsync(findShopperQuery);
            return shopperAdapter.Adapt(shoppers, typeMapper);
        }

        public async Task<IEnumerable<ShopperViewModel>> GetShoppersByGender(Gender gender)
        {
            var findShopperQuery = new FindShopperQuery(Guid.Empty, gender);
            var shoppers = await this.findShopperRepository.GetAllAsync(findShopperQuery);
            return shopperAdapter.Adapt(shoppers, typeMapper);
        }
    }
}