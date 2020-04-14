namespace AG.PaymentApp.Domain.Commands.Validations
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Core.Validations.Interface;
    using AG.PaymentApp.Domain.Services.Exceptions;
    public class PaymentValidations
    {
        private readonly IPreConditionEvaluator<NewPaymentCommand> preConditionEvaluator;

        public PaymentValidations(
            IPreConditionEvaluator<NewPaymentCommand> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public void ValidatePayment(NewPaymentCommand payment)
        {
            var paymentPreConditionEvaluator = preConditionEvaluator.Evaluate(payment);

            if (paymentPreConditionEvaluator.Failure)
            {
                throw new PreConditionEvaluatorException(paymentPreConditionEvaluator.ToMultiLine(";"));
            }
        }
    }
}
