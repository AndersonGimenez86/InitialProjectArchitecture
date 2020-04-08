namespace AG.PaymentApp.Domain.Services
{
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Services.Exceptions;
    using AG.PaymentApp.Domain.Services.Interface;
    using AG.PaymentApp.Domain.Services.Validations.Interface;

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
