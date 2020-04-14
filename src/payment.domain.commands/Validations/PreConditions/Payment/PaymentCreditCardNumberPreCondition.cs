namespace AG.PaymentApp.Domain.Core.Validations.PreConditions.Payment
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Core.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentCreditCardNumberPreCondition : IPreCondition<NewPaymentCommand>
    {
        public IOutcome Accept(NewPaymentCommand payment)
        {
            if (payment.CreditCard.Number.Length == 16)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card number is invalid {payment.CreditCard.Number}. It must have 16 characters");
        }
    }
}
