namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using Ether.Outcomes;
    using global::Payment.Domain.Commands.Validations.PreConditions;

    public class PaymentAmountPreCondition : PreCondition<PaymentCommand>
    {
        public override IOutcome Accept(PaymentCommand payment)
        {
            if (payment.Amount.Value > 0)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"The payment amount must be greater than 0.");
        }
    }
}
