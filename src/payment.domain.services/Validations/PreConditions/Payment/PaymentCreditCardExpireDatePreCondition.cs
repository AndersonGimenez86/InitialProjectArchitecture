namespace Payment.domain.services.Validations.PreConditions.Payment
{
    using System;
    using Payment.domain.Entity.Payments;
    using Payment.domain.services.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentCreditCardExpireDatePreCondition : IPreCondition<Payment>
    {
        public IOutcome Accept(Payment payment)
        {
            if (payment.CreditCardNotMasked.ExpireDate > DateTime.Now)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card invalid, it´s expired since {payment.CreditCard.ExpireDate}.");
        }
    }
}
