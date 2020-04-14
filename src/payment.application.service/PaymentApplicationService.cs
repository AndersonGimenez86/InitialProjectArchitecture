namespace AG.PaymentApp.application.services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.messaging.Events;
    using AG.PaymentApp.application.services.Adapter.Interface;
    using AG.PaymentApp.application.services.DTO.Payments;
    using AG.PaymentApp.application.services.Events.Interface;
    using AG.PaymentApp.application.services.Interface;
    using AG.PaymentApp.crosscutting.kafka.Messaging.Producers.Interface;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Payments;
    using AutoMapper;
    using Payment.Domain.Core.Bus;

    public class PaymentApplicationService : IPaymentApplicationService
    {
        private readonly IFindPaymentQueryHandler findPaymentQueryHandler;
        private readonly IPaymentCommandHandler paymentCommand;
        private readonly IEventCommandHandler<CreatePaymentEvent, Payment> paymentEventCommand;
        private readonly IMediatorHandler mediatorHandler;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToViewModel<Payment, PaymentViewModel> paymentAdapter;

        public PaymentApplicationService(
            IFindPaymentQueryHandler findPaymentQueryHandler,
            IPaymentCommandHandler paymentCommand,
            IEventCommandHandler<CreatePaymentEvent, Payment> paymentEventCommand,
            IMediatorHandler mediatorHandler,
            IMapper typeMapper,
            IAdaptEntityToViewModel<Payment, PaymentViewModel> paymentAdapter
            )
        {
            this.paymentCommand = paymentCommand;
            this.paymentEventCommand = paymentEventCommand;
            this.findPaymentQueryHandler = findPaymentQueryHandler;
            this.mediatorHandler = mediatorHandler;
            this.typeMapper = typeMapper;
            this.paymentAdapter = paymentAdapter;
        }

        public async Task<PaymentProcessingResponseViewModel> CreateAsync(PaymentProcessingViewModel paymentProcessingViewModel)
        {
            var newPaymentCommand = GetPaymentFilled(paymentProcessingViewModel);

            await mediatorHandler.SendCommand<NewPaymentCommand>(newPaymentCommand);

            var paymentProcessingResponseDTO = new PaymentProcessingResponseViewModel
            {
                PaymentID = payment.ID,
                PaymentStatus = payment.Status
            };

            return paymentProcessingResponseDTO;
        }

        public async Task<PaymentViewModel> GetAsync(Guid paymentID)
        {
            var findMerchantQuery = new FindPaymentQuery(paymentID);

            var payment = await this.findPaymentQueryHandler.GetAsync(findMerchantQuery);

            return paymentAdapter.Adapt(payment, typeMapper);
        }
        public async Task<IEnumerable<PaymentViewModel>> GetAllAsync()
        {
            var findPaymentQuery = new FindPaymentQuery();

            var payments = await this.findPaymentQueryHandler.GetAllAsync(findPaymentQuery);

            return paymentAdapter.Adapt(payments, typeMapper);
        }

        public async Task<PaymentViewModel> GetLastPaymentReceivedAsync(Guid shopperID)
        {
            var findPaymentQuery = new FindPaymentQuery(Guid.Empty, Guid.Empty, shopperID);

            var payment = await this.findPaymentQueryHandler.GetLastPaymentReceivedAsync(findPaymentQuery);

            return paymentAdapter.Adapt(payment, typeMapper);
        }

        private NewPaymentCommand GetPaymentFilled(PaymentProcessingViewModel paymentProcessingDTO)
        {
            var newPaymentCommand = this.typeMapper.Map<NewPaymentCommand>(paymentProcessingDTO);
            newPaymentCommand.Id = newPaymentCommand.Id != Guid.Empty ? newPaymentCommand.Id : Guid.NewGuid();

            return newPaymentCommand;
        }
    }
}
