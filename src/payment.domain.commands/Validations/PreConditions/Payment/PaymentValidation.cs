namespace AG.PaymentApp.Domain.Commands.Validations.Payments
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentValidation
    {
        private readonly IPreConditionEvaluator<PaymentCommand> preConditionEvaluator;

        public PaymentValidation(
            IPreConditionEvaluator<PaymentCommand> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public IOutcome ValidatePayment(PaymentCommand payment)
        {
            return preConditionEvaluator.Evaluate(payment);
        }
    }
}
