namespace AG.PaymentApp.Application.Messaging.Handlers
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Payments;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging;

    internal class PaymentEventHandler : IMessageHandler<CreateTransactionEvent>
    {
        //private readonly ILogger logger;        
        private readonly IFindPaymentQueryHandler findPaymentQueryHandler;

        public PaymentEventHandler(
            IFindPaymentQueryHandler findPaymentQueryHandler)
        {
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

                //TODO: Review here
                //await new PaymentCommandHandler().UpdateAsync(payment);
            }
        }
    }
}
