namespace AG.PaymentApp.Application.Messaging.Handlers
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Events;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Payments;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging;

    internal class PaymentEventHandler : IMessageHandler<CreateTransactionEvent>
    {
        //private readonly ILogger logger;        
        private readonly IFindPaymentRepository findPaymentRepository;

        public PaymentEventHandler(
            IFindPaymentRepository findPaymentRepository)
        {
            this.findPaymentRepository = findPaymentRepository;
        }

        public async Task HandleAsync(CreateTransactionEvent message)
        {
            var findPaymentQuery = new FindPaymentQuery(message.EventID);

            Enum.TryParse(message.TransactionStatus, out PaymentStatus status);

            var payment = await this.findPaymentRepository.GetAsync(findPaymentQuery.PaymentID);

            if (payment != null)
            {
                //TODO: Review here
                //await new PaymentCommandHandler().UpdateAsync(payment);
            }
        }
    }
}
