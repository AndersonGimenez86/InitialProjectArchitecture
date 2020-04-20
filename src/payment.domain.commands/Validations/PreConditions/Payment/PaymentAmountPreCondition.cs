namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentAmountPreCondition : IPreCondition<PaymentCommand>
    {
        public IOutcome Accept(PaymentCommand payment)
        {
            if (payment.Amount.Value > 0)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"The payment amount must be greater than 0.");
        }
    }
}
