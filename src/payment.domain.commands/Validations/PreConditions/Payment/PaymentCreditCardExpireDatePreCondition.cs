namespace AG.PaymentApp.Domain.Core.Validations.PreConditions.Payment
{
    using System;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Core.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentCreditCardExpireDatePreCondition : IPreCondition<NewPaymentCommand>
    {
        public IOutcome Accept(NewPaymentCommand payment)
        {
            if (payment.CreditCard.ExpireDate > DateTime.Now)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card invalid, it´s expired since {payment.CreditCard.ExpireDate}.");
        }
    }
}
