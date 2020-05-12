namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.queries.Interface;
    using Ether.Outcomes;
    using global::Payment.Domain.Commands.Validations.PreConditions;

    public class PaymentExistsShopperAssociatedPreCondition : PreCondition<PaymentCommand>
    {
        private readonly IFindShopperRepository findShopperRepository;

        public PaymentExistsShopperAssociatedPreCondition(IFindShopperRepository findShopperRepository)
        {
            this.findShopperRepository = findShopperRepository;
        }

        public override IOutcome Accept(PaymentCommand payment)
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
            return await this.findShopperRepository.GetAsync(shopperID) != null;
        }
    }
}
