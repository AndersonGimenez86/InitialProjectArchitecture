namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using Ether.Outcomes;
    using global::Payment.Domain.Commands.Validations.PreConditions;

    public class PaymentCreditCardNumberPreCondition : PreCondition<NewPaymentCommand>
    {
        public override IOutcome Accept(NewPaymentCommand payment)
        {
            if (payment.CreditCard.Number.Length == 16)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Credit card number is invalid {payment.CreditCard.Number}. It must have 16 characters");
        }
    }
}
