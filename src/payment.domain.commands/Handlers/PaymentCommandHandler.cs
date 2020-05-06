namespace AG.PaymentApp.Domain.Commands.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ag.PaymentApp.Domain.Commands.Handlers;
    using AG.Payment.Domain.Core.Bus;
    using AG.Payment.Domain.Events;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.DataProtection;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.DataProtection;

    public class PaymentCommandHandler : CommandHandler,
        IRequestHandler<NewPaymentCommand, bool>
    //IRequestHandler<UpdateCustomerCommand, bool>,
    //IRequestHandler<RemoveCustomerCommand, bool>
    {
        private readonly IPaymentRepository repository;
        private readonly IMapper typeMapper;
        private readonly IMediatorHandler mediatorHandler;
        private readonly IDataProtectionProvider dataProtectionProvider;
        private readonly ITopicProducer<PaymentRegisteredEvent> topicProducer;

        public PaymentCommandHandler(
        IPaymentRepository paymentEventRepository,
        IMediatorHandler mediatorHandler,
        IDataProtectionProvider dataProtectionProvider,
        ITopicProducer<PaymentRegisteredEvent> topicProducer,
        INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)
        {
            this.repository = paymentEventRepository;
            this.mediatorHandler = mediatorHandler;
            this.dataProtectionProvider = dataProtectionProvider;
            this.topicProducer = topicProducer;
        }

        public Task<bool> Handle(NewPaymentCommand newPaymentCommand, CancellationToken cancellationToken)
        {
            if (!newPaymentCommand.IsValid())
            {
                NotifyValidationErrors(newPaymentCommand);
                return Task.FromResult(false);
            }

            var creditCardProtected = CreditCardDataProtection.ProtectSensitiveData(dataProtectionProvider, newPaymentCommand.CreditCard);

            var payment = new Payment(newPaymentCommand.Id, newPaymentCommand.ShopperID, newPaymentCommand.MerchantID, creditCardProtected, newPaymentCommand.Amount);

            repository.SaveAsync(payment);

            if (Commit())
            {
                var paymentRegisteredEvent = new PaymentRegisteredEvent(payment.ShopperID, payment.MerchantID, payment.TransactionID, payment.Amount, payment.CreditCard);
                mediatorHandler.RaiseEvent(paymentRegisteredEvent);
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