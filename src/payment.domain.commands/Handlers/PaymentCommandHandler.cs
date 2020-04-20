namespace AG.PaymentApp.Domain.Commands.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ag.PaymentApp.Domain.Commands.Handlers;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.DataProtection;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.DataProtection;
    using Payment.Domain.Core.Bus;

    public class PaymentCommandHandler : CommandHandler,
        IRequestHandler<NewPaymentCommand, bool>
    //   IRequestHandler<UpdateCustomerCommand, bool>,
    //IRequestHandler<RemoveCustomerCommand, bool>
    {
        private readonly IPaymentRepository repository;
        private readonly IMapper typeMapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediatorHandler mediatorHandler;
        private readonly IDataProtectionProvider dataProtectionProvider;

        public PaymentCommandHandler(
        IPaymentRepository paymentEventRepository,
        IMapper typeMapper,
        IUnitOfWork unitOfWork,
        IMediatorHandler mediatorHandler,
        IDataProtectionProvider dataProtectionProvider,
        INotificationHandler<DomainNotification> notifications) : base(unitOfWork, mediatorHandler, notifications)
        {
            this.repository = paymentEventRepository;
            this.typeMapper = typeMapper;
            this.unitOfWork = unitOfWork;
            this.mediatorHandler = mediatorHandler;
            this.dataProtectionProvider = dataProtectionProvider;
        }

        public Task<bool> Handle(NewPaymentCommand newPaymentCommand, CancellationToken cancellationToken)
        {
            //update payment status to processing
            //if (kafkaResponse.Success)
            //{
            //    payment.Status = PaymentStatus.Processing;
            //    await this.paymentCommand.UpdateAsync(payment);
            ////}
            if (!newPaymentCommand.IsValid())
            {
                NotifyValidationErrors(newPaymentCommand);
                return Task.FromResult(false);
            }

            var creditCardProtected = CreditCardDataProtection.ProtectSensitiveData(dataProtectionProvider, newPaymentCommand.CreditCard);

            var payment = new Payment(newPaymentCommand.Id, newPaymentCommand.ShopperID, newPaymentCommand.MerchantID, creditCardProtected, newPaymentCommand.Amount, newPaymentCommand.Status);

            repository.SaveAsync(payment);

            if (Commit())
            {
                //mediatorHandler.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }

            return Task.FromResult(true);
        }

        //public Task<bool> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        //{
        //    if (!message.IsValid())
        //    {
        //        NotifyValidationErrors(message);
        //        return Task.FromResult(false);
        //    }

        //    var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
        //    var existingCustomer = _customerRepository.GetByEmail(customer.Email);

        //    if (existingCustomer != null && existingCustomer.Id != customer.Id)
        //    {
        //        if (!existingCustomer.Equals(customer))
        //        {
        //            Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
        //            return Task.FromResult(false);
        //        }
        //    }

        //    _customerRepository.Update(customer);

        //    if (Commit())
        //    {
        //        Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
        //    }

        //    return Task.FromResult(true);
        //}

        //public Task<bool> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        //{
        //    if (!message.IsValid())
        //    {
        //        NotifyValidationErrors(message);
        //        return Task.FromResult(false);
        //    }

        //    _customerRepository.Remove(message.Id);

        //    if (Commit())
        //    {
        //        Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
        //    }

        //    return Task.FromResult(true);
        //}
    }
}