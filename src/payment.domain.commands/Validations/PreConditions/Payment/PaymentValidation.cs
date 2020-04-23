namespace AG.PaymentApp.Domain.Commands.Validations.Payments
{
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentValidation : ICommandValidation<PaymentCommand>
    {
        private readonly IPreConditionEvaluator<PaymentCommand> preConditionEvaluator;

        public PaymentValidation(
            IPreConditionEvaluator<PaymentCommand> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public IOutcome ValidateCommand(PaymentCommand payment)
        {
            return preConditionEvaluator.Evaluate(payment);
        }
    }
}
