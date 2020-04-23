namespace AG.PaymentApp.Domain.commands.Shoopers
{
    using System;
    using System.Threading.Tasks;
    using Ag.PaymentApp.Domain.Commands.Handlers;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AutoMapper;
    using MediatR;

    public class ShopperCommandHandler : CommandHandler
    {
        private readonly IShopperRepository repository;
        private readonly IMapper typeMapper;
        private readonly IMediatorHandler mediatorHandler;

        public ShopperCommandHandler(
            IShopperRepository eventRepository,
            IMapper typeMapper,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)

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
