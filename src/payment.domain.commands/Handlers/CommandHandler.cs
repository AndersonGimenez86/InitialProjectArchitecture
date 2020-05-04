namespace Ag.PaymentApp.Domain.Commands.Handlers
{
    using AG.Payment.Domain.Core.Bus;
    using AG.Payment.Domain.Core.Commands;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using MediatR;

    public class CommandHandler
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediatorHandler mediatorHandler;
        private readonly DomainNotificationHandler notifications;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> notifications)
        {
            this.unitOfWork = unitOfWork;
            this.notifications = (DomainNotificationHandler)notifications;
            this.mediatorHandler = mediatorHandler;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (notifications.HasNotifications())
                return false;

            if (unitOfWork.Commit())
                return true;

            mediatorHandler.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
