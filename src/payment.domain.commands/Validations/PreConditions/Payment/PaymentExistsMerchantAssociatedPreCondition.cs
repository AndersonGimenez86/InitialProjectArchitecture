namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using Ether.Outcomes;

    public class PaymentExistsMerchantAssociatedPreCondition : IPreCondition<PaymentCommand>
    {
        private readonly IFindMerchantQueryHandler merchantQuery;

        public PaymentExistsMerchantAssociatedPreCondition(IFindMerchantQueryHandler merchantQuery)
        {
            this.merchantQuery = merchantQuery;
        }

        public IOutcome Accept(PaymentCommand payment)
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
