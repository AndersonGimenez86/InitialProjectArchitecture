namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
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
