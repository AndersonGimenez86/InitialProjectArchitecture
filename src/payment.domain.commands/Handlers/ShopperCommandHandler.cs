namespace AG.PaymentApp.Domain.commands.Shoopers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ag.PaymentApp.Domain.Commands.Handlers;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using MediatR;

    public class ShopperCommandHandler : CommandHandler
    {
        private readonly IShopperRepository repository;
        private readonly IMediatorHandler mediatorHandler;

        public ShopperCommandHandler(
            IShopperRepository eventRepository,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)

        {
            this.repository = eventRepository;
        }

        public Task<bool> Handle(NewShopperCommand newPaymentCommand, CancellationToken cancellationToken)
        {
            if (!newPaymentCommand.IsValid())
            {
                NotifyValidationErrors(newPaymentCommand);
                return Task.FromResult(false);
            }

            var shopper = new Shopper(newPaymentCommand.Id, newPaymentCommand.FirstName, newPaymentCommand.LastName, newPaymentCommand.Email,
                                      newPaymentCommand.Gender, newPaymentCommand.BirthDate, newPaymentCommand.Address);

            repository.SaveAsync(shopper);

            return Task.FromResult(true);
        }
    }
}
