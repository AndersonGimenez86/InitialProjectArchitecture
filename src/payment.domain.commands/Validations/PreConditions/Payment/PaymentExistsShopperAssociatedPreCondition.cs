namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Shoppers;
    using Ether.Outcomes;

    public class PaymentExistsShopperAssociatedPreCondition : IPreCondition<PaymentCommand>
    {
        private readonly IFindShopperQueryHandler shopperQuery;

        public PaymentExistsShopperAssociatedPreCondition(IFindShopperQueryHandler shopperQuery)
        {
            this.shopperQuery = shopperQuery;
        }

        public IOutcome Accept(PaymentCommand payment)
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
