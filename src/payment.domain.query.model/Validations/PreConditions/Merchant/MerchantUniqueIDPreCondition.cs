namespace AG.PaymentApp.Domain.Query.Validations.PreConditions.Merchant
{
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using AG.PaymentApp.Domain.Query.Validations.Interface;
    using Ether.Outcomes;

    public class MerchantUniqueIDPreCondition : IPreCondition<Merchant>
    {
        private readonly IFindMerchantQueryHandler findMerchantQueryHandler;

        public MerchantUniqueIDPreCondition(IFindMerchantQueryHandler findMerchantQueryHandler)
        {
            this.findMerchantQueryHandler = findMerchantQueryHandler;
        }

        public IOutcome Accept(Merchant newEntity)
        {
            var findMerchantQuery = new FindMerchantQuery(newEntity.Id);

            var result = this.findMerchantQueryHandler.GetAsync(findMerchantQuery).GetAwaiter();

            var merchant = result.GetResult();

            if (merchant is null)
                return Outcomes.Success();

            return Outcomes.Failure<int[]>().WithMessage($"Merchant ID is alredy in use!");
        }
    }
}
