namespace AG.PaymentApp.Domain.commands.Merchants
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ag.PaymentApp.Domain.Commands.Handlers;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Domain.Commands;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using MediatR;

    public class MerchantCommandHandler : CommandHandler
    {
        private readonly IMerchantRepository repository;
        private readonly IMediatorHandler mediatorHandler;

        public MerchantCommandHandler(
            IMerchantRepository eventRepository,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)
        {
            this.repository = eventRepository;
            this.mediatorHandler = mediatorHandler;
        }

        public Task<bool> Handle(NewMerchantCommand newMerchantCommand, CancellationToken cancellationToken)
        {
            if (!newMerchantCommand.IsValid())
            {
                NotifyValidationErrors(newMerchantCommand);
                return Task.FromResult(false);
            }

            var merchant = new Merchant(newMerchantCommand.Id, newMerchantCommand.Name, newMerchantCommand.Acronym,
                newMerchantCommand.Currency, newMerchantCommand.Country, newMerchantCommand.IsVisible,
                newMerchantCommand.IsOnline);

            repository.SaveAsync(merchant);

            return Task.FromResult(true);
        }
    }
}