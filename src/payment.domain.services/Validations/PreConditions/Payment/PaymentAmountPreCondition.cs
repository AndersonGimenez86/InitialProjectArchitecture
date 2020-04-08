namespace Payment.domain.services.Validations.PreConditions.Payment
{
    using Payment.domain.Entity.Payments;
    using Payment.domain.services.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentAmountPreCondition : IPreCondition<Payment>
    {
        public IOutcome Accept(Payment payment)
        {
            if (payment.Amount.Value > 0)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"The payment amount must be greater than 0.");
        }
    }
}
