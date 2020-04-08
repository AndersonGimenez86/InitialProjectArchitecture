namespace AG.PaymentApp.application.services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.application.services.Adapter.Interface;
    using AG.PaymentApp.application.services.DTO.Shoppers;
    using AG.PaymentApp.application.services.Interface;
    using AG.PaymentApp.Domain.commands.Interface;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Shoppers;

    public class ShopperApplicationService : IShopperApplicationService
    {
        private readonly IShopperCommandHandler shopperCommand;
        private readonly IFindShopperQueryHandler findShopperQueryHandler;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToDTO<Shopper, ShopperDTO> shopperAdapter;

        public ShopperApplicationService(
            IShopperCommandHandler shopperCommand,
            IFindShopperQueryHandler findShopperQueryHandler,
            IMapper typeMapper,
            IAdaptEntityToDTO<Shopper, ShopperDTO> shopperAdapter
            )
        {
            this.shopperCommand = shopperCommand;
            this.findShopperQueryHandler = findShopperQueryHandler;
            this.typeMapper = typeMapper;
            this.shopperAdapter = shopperAdapter;
        }

        public async Task CreateAsync(ShopperDTO shopperDTO)
        {
            var shopper = this.typeMapper.Map<Shopper>(shopperDTO);
            shopper.ID = shopper.ID != Guid.Empty ? shopper.ID : Guid.NewGuid();
            shopper.DateCreated = DateTime.Now;

            shopper.SetAddress(shopper.Address);

            await shopperCommand.ExecuteAsync(shopper);
        }

        public async Task<ShopperDTO> GetAsync(Guid shopperID)
        {
            var findShopperQuery = new FindShopperQuery(shopperID, Gender.None);

            var shopper = await this.findShopperQueryHandler.GetAsync(findShopperQuery);

            return shopperAdapter.Adapt(shopper, typeMapper);
        }

        public async Task<IEnumerable<ShopperDTO>> GetAllAsync()
        {
            var findShopperQuery = new FindShopperQuery(Guid.Empty, Gender.None);

            var shoppers = await this.findShopperQueryHandler.GetAllAsync(findShopperQuery);

            return shopperAdapter.Adapt(shoppers, typeMapper);
        }

        public async Task<IEnumerable<ShopperDTO>> GetShoppersByGender(Gender gender)
        {
            var findShopperQuery = new FindShopperQuery(Guid.Empty, gender);

            var shoppers = await this.findShopperQueryHandler.GetShoppersByGender(findShopperQuery);

            return shopperAdapter.Adapt(shoppers, typeMapper);
        }
    }
}