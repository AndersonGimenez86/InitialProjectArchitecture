namespace AG.PaymentApp.Domain.Core.Validations.PreConditions.Payment
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Core.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentAmountPreCondition : IPreCondition<NewPaymentCommand>
    {
        public IOutcome Accept(NewPaymentCommand payment)
        {
            if (payment.Amount.Value > 0)
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"The payment amount must be greater than 0.");
        }
    }
}
