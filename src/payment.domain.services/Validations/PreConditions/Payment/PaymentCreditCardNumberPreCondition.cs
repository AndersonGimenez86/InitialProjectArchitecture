namespace Payment.domain.services.Validations.PreConditions.Payment
{
    using Payment.domain.Entity.Payments;
    using Payment.domain.services.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentCreditCardNumberPreCondition : IPreCondition<Payment>
    {
        public IOutcome Accept(Payment payment)
        {
            if (payment.CreditCardNotMasked.Number.Length == 16)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card number is invalid {payment.CreditCard.Number}. It must have 16 characters");
        }
    }
}
