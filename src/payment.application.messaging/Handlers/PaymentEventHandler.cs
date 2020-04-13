namespace AG.PaymentApp.application.messaging.Handlers
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.messaging.Events;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Payments;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging;

    internal class PaymentEventHandler : IMessageHandler<CreateTransactionEvent>
    {
        //private readonly ILogger logger;
        private readonly IPaymentCommandHandler paymentCommand;
        private readonly IFindPaymentQueryHandler findPaymentQueryHandler;

        public PaymentEventHandler(
            IPaymentCommandHandler paymentCommand,
            IFindPaymentQueryHandler findPaymentQueryHandler)
        {
            this.paymentCommand = paymentCommand;
            this.findPaymentQueryHandler = findPaymentQueryHandler;
        }

        public async Task HandleAsync(CreateTransactionEvent message)
        {
            var findPaymentQuery = new FindPaymentQuery(message.EventID);

            Enum.TryParse(message.TransactionStatus, out PaymentStatus status);

            var payment = await this.findPaymentQueryHandler.GetAsync(findPaymentQuery);

            if (payment != null)
            {
                payment.Status = status;
                payment.TransactionID = message.TransactionID;

                await this.paymentCommand.UpdateAsync(payment);
            }
        }
    }
}
