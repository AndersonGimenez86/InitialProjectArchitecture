namespace Ag.PaymentApp.Domain.Commands.Handlers
{
    using AG.Payment.Domain.Core.Bus;
    using AG.Payment.Domain.Core.Commands;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using MediatR;

    public class CommandHandler
    {
        private readonly IMediatorHandler mediatorHandler;
        private readonly DomainNotificationHandler notifications;

        public CommandHandler(IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> notifications)
        {
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

        protected bool Commit()
        {
            if (notifications.HasNotifications())
                return false;

            return true;
        }
    }
}
