namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentCreditCardCVVPreCondition : IPreCondition<NewPaymentCommand>
    {
        public IOutcome Accept(NewPaymentCommand payment)
        {
            if (Math.Floor(Math.Log10(payment.CreditCard.CVV) + 1) == 3)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card CVV is invalid.");
        }
    }
}

