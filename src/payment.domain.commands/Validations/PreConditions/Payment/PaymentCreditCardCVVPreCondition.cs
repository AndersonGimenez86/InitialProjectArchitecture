namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using AG.PaymentApp.Domain.Commands.Payments;
    using Ether.Outcomes;
    using global::Payment.Domain.Commands.Validations.PreConditions;

    public class PaymentCreditCardCVVPreCondition : PreCondition<NewPaymentCommand>
    {
        public override IOutcome Accept(NewPaymentCommand payment)
        {
            if (Math.Floor(Math.Log10(payment.CreditCard.CVV) + 1) == 3)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card CVV is invalid.");
        }
    }
}

