namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.queries.Interface;
    using Ether.Outcomes;

    public class PaymentExistsShopperAssociatedPreCondition : IPreCondition<PaymentCommand>
    {
        private readonly IFindShopperRepository findShopperRepository;

        public PaymentExistsShopperAssociatedPreCondition(IFindShopperRepository findShopperRepository)
        {
            this.findShopperRepository = findShopperRepository;
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
            return await this.findShopperRepository.GetAsync(shopperID) != null;
        }
    }
}
