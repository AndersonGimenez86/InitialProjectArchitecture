namespace AG.PaymentApp.Domain.commands.Shoopers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.Domain.commands.Interface;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.repository.commands.Interface;

    public class ShopperCommandHandler : IShopperCommandHandler
    {
        private readonly IShopperEventRepository eventRepository;
        private readonly IMapper typeMapper;

        public ShopperCommandHandler(
            IShopperEventRepository eventRepository,
            IMapper typeMapper)
        {
            this.eventRepository = eventRepository;
            this.typeMapper = typeMapper;
        }

        public async Task ExecuteAsync(Shopper shopper)
        {
            try
            {
                var shopperMongo = this.typeMapper.Map<ShopperMongo>(shopper);

                var shopperDataCommand = new ShopperDataCommand(shopperMongo);

                //save payment event into mongoDB
                await this.eventRepository.SaveAsync(shopperDataCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ShopperDataCommand> GetAsync(Guid commandID)
        {
            return null;
        }
    }
}
