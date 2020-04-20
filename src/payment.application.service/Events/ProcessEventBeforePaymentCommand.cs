namespace AG.PaymentApp.Application.Services.Events
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Services.Events.Interface;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Payments;

    public class ProcessEventBeforePaymentCommand : IEventCommandHandler<CreatePaymentEvent, Payment>
    {
        private readonly IFindPaymentQueryHandler findPaymentQueryHandler;

        public ProcessEventBeforePaymentCommand(IFindPaymentQueryHandler findPaymentQueryHandler)
        {
            this.findPaymentQueryHandler = findPaymentQueryHandler;
        }

        public async Task<Payment> HandleAsync(CreatePaymentEvent command)
        {
            var findPaymentQuery = new FindPaymentQuery(Guid.Empty, Guid.Empty, command.ShopperID);

            var lastPayment = await this.findPaymentQueryHandler.GetLastPaymentReceivedAsync(findPaymentQuery);

            return lastPayment;
        }
    }
}