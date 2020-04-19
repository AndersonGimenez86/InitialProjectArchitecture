namespace AG.PaymentApp.Domain.commands.Shoopers
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.repository.commands.Interface;
    using AutoMapper;
    using MediatR;
    using Payment.Domain.Commands.Handlers;
    using Payment.Domain.Core.Bus;
    using Payment.Domain.Interface;

    public class ShopperCommandHandler : CommandHandler
    {
        private readonly IShopperRepository eventRepository;
        private readonly IMapper typeMapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediatorHandler mediatorHandler;

        public ShopperCommandHandler(
            IShopperRepository eventRepository,
            IMapper typeMapper,
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notifications) : base(unitOfWork, mediatorHandler, notifications)

        {
            this.eventRepository = eventRepository;
            this.typeMapper = typeMapper;
        }

        public async Task ExecuteAsync(Shopper shopper)
        {
            try
            {
                var shopperMongo = this.typeMapper.Map<ShopperMongo>(shopper);

                var shopperDataCommand = new ShopperCommand(shopperMongo);

                //save payment event into mongoDB
                await this.eventRepository.SaveAsync(shopperDataCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ShopperCommand> GetAsync(Guid commandID)
        {
            return null;
        }
    }
}
