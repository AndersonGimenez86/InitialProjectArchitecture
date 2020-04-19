namespace AG.PaymentApp.Domain.Core.Services
{
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Query.Validations.Interface;
    using AG.PaymentApp.Domain.Services.Exceptions;

    public class MerchantValidation
    {
        private readonly IPreConditionEvaluator<Merchant> preConditionEvaluator;

        public MerchantValidation(IPreConditionEvaluator<Merchant> preConditionEvaluator)
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
