namespace AG.PaymentApp.Domain.commands.Shoopers
{
    using System;
    using System.Threading.Tasks;
    using Ag.PaymentApp.Domain.Commands.Handlers;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AutoMapper;
    using MediatR;
    using Payment.Domain.Core.Bus;

    public class ShopperCommandHandler : CommandHandler
    {
        private readonly IShopperRepository repository;
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
            this.repository = eventRepository;
            this.typeMapper = typeMapper;
        }

        public async Task ExecuteAsync(ShopperCommand shopperCommand)
        {
            try
            {
                var shopper = this.typeMapper.Map<Shopper>(shopperCommand);
                await this.repository.SaveAsync(shopper);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
