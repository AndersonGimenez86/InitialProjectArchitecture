namespace AG.PaymentApp.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Application.Services.Adapter.Interface;
    using AG.PaymentApp.Application.Services.DTO.Payments;
    using AG.PaymentApp.Application.Services.Interface;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Payments;
    using AutoMapper;
    using MediatR;

    public class PaymentApplicationService : IPaymentApplicationService
    {
        private readonly IFindPaymentQueryHandler findPaymentQueryHandler;
        private readonly DomainNotificationHandler notifications;
        private readonly IMediatorHandler mediatorHandler;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToViewModel<Payment, PaymentViewModel> paymentAdapter;

        public PaymentApplicationService(
            IFindPaymentQueryHandler findPaymentQueryHandler,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IMapper typeMapper,
            IAdaptEntityToViewModel<Payment, PaymentViewModel> paymentAdapter
            )
        {
            this.findPaymentQueryHandler = findPaymentQueryHandler;
            this.notifications = (DomainNotificationHandler)notifications;
            this.mediatorHandler = mediatorHandler;
            this.typeMapper = typeMapper;
            this.paymentAdapter = paymentAdapter;
        }

        public async Task<PaymentProcessingResponseViewModel> CreateAsync(PaymentProcessingViewModel paymentProcessingViewModel)
        {
            var newPaymentCommand = GetPaymentFilled(paymentProcessingViewModel);

            await mediatorHandler.SendCommand<NewPaymentCommand>(newPaymentCommand);

            var errorMessages = notifications.GetNotifications().Select(n => n.Value);

            var paymentProcessingResponseViewModel = new PaymentProcessingResponseViewModel
            {
                PaymentID = newPaymentCommand.Id,
                PaymentStatus = errorMessages.Any() ? PaymentStatus.Rejected : PaymentStatus.Processing,
                ErrorMessage = errorMessages
            };

            return paymentProcessingResponseViewModel;
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
