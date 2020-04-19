namespace AG.PaymentApp.Domain.Query.Validations.Payments
{
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Query.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentValidation
    {
        private readonly IPreConditionEvaluator<Payment> preConditionEvaluator;

        public PaymentValidation(
            IPreConditionEvaluator<Payment> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public IOutcome ValidatePayment(Payment payment)
        {
            return preConditionEvaluator.Evaluate(payment);
        }
    }
}
