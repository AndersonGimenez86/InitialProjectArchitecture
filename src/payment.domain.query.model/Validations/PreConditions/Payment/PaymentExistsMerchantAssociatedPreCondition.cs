namespace AG.PaymentApp.Domain.Query.Validations.PreConditions.Payment
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using AG.PaymentApp.Domain.Query.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentExistsMerchantAssociatedPreCondition : IPreCondition<Payment>
    {
        private readonly IFindMerchantQueryHandler merchantQuery;

        public PaymentExistsMerchantAssociatedPreCondition(IFindMerchantQueryHandler merchantQuery)
        {
            this.merchantQuery = merchantQuery;
        }

        public IOutcome Accept(Payment payment)
        {
            var merchantExists = FindMerchantByID(payment.MerchantID).GetAwaiter();

            if (merchantExists.GetResult())
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Merchant not found to process the payment.");
        }

        private async Task<bool> FindMerchantByID(Guid merchandID)
        {
            var findMerchantQuery = new FindMerchantQuery(merchandID, string.Empty, string.Empty);

            return await this.merchantQuery.GetAsync(findMerchantQuery) != null;
        }
    }
}
