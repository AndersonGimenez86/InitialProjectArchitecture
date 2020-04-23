namespace AG.Payment.Domain.Commands.Validations.Interface
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using Ether.Outcomes;

    public interface IPaymentValidation
    {
        IOutcome ValidatePayment(PaymentCommand payment);
    }
}
