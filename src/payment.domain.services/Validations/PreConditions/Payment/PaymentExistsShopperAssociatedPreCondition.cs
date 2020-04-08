namespace Payment.domain.services.Validations.PreConditions.Payment
{
    using System;
    using System.Threading.Tasks;
    using Payment.domain.Entity.Payments;
    using Payment.domain.query.Interface;
    using Payment.domain.query.Shoppers;
    using Payment.domain.services.Validations.Interface;
    using Ether.Outcomes;

    public class PaymentExistsShopperAssociatedPreCondition : IPreCondition<Payment>
    {
        private readonly IFindShopperQueryHandler shopperQuery;

        public PaymentExistsShopperAssociatedPreCondition(IFindShopperQueryHandler shopperQuery)
        {
            this.shopperQuery = shopperQuery;
        }

        public IOutcome Accept(Payment payment)
        {
            var shopperExists = FindShopperByID(payment.ShopperID).GetAwaiter();

            if (shopperExists.GetResult())
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Shopper not found to process the payment.");
        }

        private async Task<bool> FindShopperByID(Guid shopperID)
        {
            var findShopperQuery = new FindShopperQuery(shopperID, domain.Enum.Gender.None);

            return await this.shopperQuery.GetAsync(findShopperQuery) != null;
        }
    }
}
