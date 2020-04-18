namespace AG.PaymentApp.Domain.Commands.Validations
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Core.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentValidations
    {
        private readonly IPreConditionEvaluator<NewPaymentCommand> preConditionEvaluator;

        public PaymentValidations(
            IPreConditionEvaluator<NewPaymentCommand> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public IOutcome ValidatePayment(NewPaymentCommand payment)
        {
            return preConditionEvaluator.Evaluate(payment);
        }
    }
}
