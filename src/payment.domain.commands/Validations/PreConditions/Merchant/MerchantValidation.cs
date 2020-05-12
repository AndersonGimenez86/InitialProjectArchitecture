namespace AG.PaymentApp.Domain.Commands.Services
{
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using Ether.Outcomes;
    using global::Payment.Domain.Commands.Validations.PreConditions;

    public class MerchantValidation : CommandValidation<MerchantCommand>
    {
        private readonly IPreConditionEvaluator<MerchantCommand> preConditionEvaluator;

        public MerchantValidation(IPreConditionEvaluator<MerchantCommand> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public override IOutcome ValidateCommand(MerchantCommand merchant)
        {
            return preConditionEvaluator.Evaluate(merchant);
        }
    }
}
