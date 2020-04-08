namespace AG.PaymentApp.Domain.Services.Validations.PreConditions.Payment
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Shoppers;
    using AG.PaymentApp.Domain.Services.Validations.Interface;
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
            var findShopperQuery = new FindShopperQuery(shopperID, Gender.None);

            return await this.shopperQuery.GetAsync(findShopperQuery) != null;
        }
    }
}
