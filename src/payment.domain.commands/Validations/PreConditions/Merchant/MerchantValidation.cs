namespace AG.PaymentApp.Domain.Commands.Services
{
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using Ether.Outcomes;

    public class MerchantValidation : ICommandValidation<MerchantCommand>
    {
        private readonly IPreConditionEvaluator<MerchantCommand> preConditionEvaluator;

        public MerchantValidation(IPreConditionEvaluator<MerchantCommand> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public IOutcome ValidateCommand(MerchantCommand merchant)
        {
            return preConditionEvaluator.Evaluate(merchant);
        }
    }
}
