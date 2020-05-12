namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using AG.PaymentApp.Domain.Commands.Payments;
    using Ether.Outcomes;
    using global::Payment.Domain.Commands.Validations.PreConditions;

    public class PaymentCreditCardExpireDatePreCondition : PreCondition<NewPaymentCommand>
    {
        public override IOutcome Accept(NewPaymentCommand payment)
        {
            if (payment.CreditCard.ExpireDate > DateTime.Now)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card invalid, it´s expired since {payment.CreditCard.ExpireDate}.");
        }
    }
}
