namespace Payment.domain.services.Validations.PreConditions.Payment
{
    using System;
    using Payment.domain.Entity.Payments;
    using Payment.domain.services.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentCreditCardCVVPreCondition : IPreCondition<Payment>
    {
        public IOutcome Accept(Payment payment)
        {
            if (Math.Floor(Math.Log10(payment.CreditCardNotMasked.CVV) + 1) == 3)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card CVV is invalid.");
        }
    }
}

