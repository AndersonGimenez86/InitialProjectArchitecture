namespace AG.PaymentApp.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Application.Services.Adapter.Interface;
    using AG.PaymentApp.Application.Services.DTO.Payments;
    using AG.PaymentApp.Application.Services.Interface;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Payments;
    using AutoMapper;

    public class PaymentApplicationService : IPaymentApplicationService
    {
        private readonly IFindPaymentQueryHandler findPaymentQueryHandler;
        //private readonly IEventCommandHandler<CreatePaymentEvent, Payment> paymentEventCommand;
        private readonly IMediatorHandler mediatorHandler;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToViewModel<Payment, PaymentViewModel> paymentAdapter;

        public PaymentApplicationService(
            IFindPaymentQueryHandler findPaymentQueryHandler,
            IMediatorHandler mediatorHandler,
            IMapper typeMapper,
            IAdaptEntityToViewModel<Payment, PaymentViewModel> paymentAdapter
            )
        {
            this.findPaymentQueryHandler = findPaymentQueryHandler;
            this.mediatorHandler = mediatorHandler;
            this.typeMapper = typeMapper;
            this.paymentAdapter = paymentAdapter;
        }

        public async Task<PaymentProcessingResponseViewModel> CreateAsync(PaymentProcessingViewModel paymentProcessingViewModel)
        {
            var newPaymentCommand = GetPaymentFilled(paymentProcessingViewModel);

            await mediatorHandler.SendCommand<NewPaymentCommand>(newPaymentCommand);

            //var paymentProcessingResponseDTO = new PaymentProcessingResponseViewModel
            //{
            //    PaymentID = payment.ID,
            //    PaymentStatus = payment.Status
            //};

            //return paymentProcessingResponseDTO;

            return null;
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

        private NewPaymentCommand GetPaymentFilled(PaymentProcessingViewModel paymentProcessingViewModel)
        {
            var newPaymentCommand = this.typeMapper.Map<NewPaymentCommand>(paymentProcessingViewModel);
            newPaymentCommand.Id = newPaymentCommand.Id != Guid.Empty ? newPaymentCommand.Id : Guid.NewGuid();

            return newPaymentCommand;
        }
    }
}
