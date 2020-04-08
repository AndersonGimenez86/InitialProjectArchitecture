namespace Payment.domain.services
{
    using Payment.domain.Entity.Merchants;
    using Payment.domain.services.Exceptions;
    using Payment.domain.services.Services.Interface;
    using Payment.domain.services.Validations.Interface;

    public class MerchantService : IMerchantService
    {
        private readonly IPreConditionEvaluator<Merchant> preConditionEvaluator;

        public MerchantService(IPreConditionEvaluator<Merchant> preConditionEvaluator)
        {
            this.preConditionEvaluator = preConditionEvaluator;
        }

        public void ValidateMerchant(Merchant merchant)
        {
            var merchantPreConditionEvaluator = this.preConditionEvaluator.Evaluate(merchant);

            if (merchantPreConditionEvaluator.Failure)
            {
                throw new PreConditionEvaluatorException(merchantPreConditionEvaluator.ToMultiLine(";"));
            }
        }
    }
}
