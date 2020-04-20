namespace AG.PaymentApp.Domain.Commands.Services
{
    using AG.PaymentApp.Domain.commands;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Services.Exceptions;

    public class MerchantValidation
    {
        private readonly IPreConditionEvaluator<MerchantCommand> preConditionEvaluator;

        public MerchantValidation(IPreConditionEvaluator<MerchantCommand> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public void ValidateMerchant(MerchantCommand merchant)
        {
            var merchantPreConditionEvaluator = this.preConditionEvaluator.Evaluate(merchant);

            if (merchantPreConditionEvaluator.Failure)
            {
                throw new PreConditionEvaluatorException(merchantPreConditionEvaluator.ToMultiLine(";"));
            }
        }
    }
}
