namespace AG.PaymentApp.Domain.Services.Validations.PreConditions.Payment
{
    using System;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Services.Validations.Interface;
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
