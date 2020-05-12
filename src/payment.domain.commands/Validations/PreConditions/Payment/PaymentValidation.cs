namespace AG.PaymentApp.Domain.Commands.Validations.Payments
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using Ether.Outcomes;
    using global::Payment.Domain.Commands.Validations.PreConditions;

    public class PaymentValidation : CommandValidation<PaymentCommand>
    {
        private readonly IPreConditionEvaluator<PaymentCommand> preConditionEvaluator;

        public PaymentValidation(
            IPreConditionEvaluator<PaymentCommand> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public override IOutcome ValidateCommand(PaymentCommand payment)
        {
            return preConditionEvaluator.Evaluate(payment);
        }
    }
}
