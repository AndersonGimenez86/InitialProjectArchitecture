namespace Payment.domain.services.Validations.PreConditions.Merchant
{
    using Payment.domain.Entity.Merchants;
    using Payment.domain.query.Interface;
    using Payment.domain.query.Merchants;
    using Payment.domain.services.Validations.Interface;
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
            var findMerchantQuery = new FindMerchantQuery(newEntity.ID);

            var result = this.findMerchantQueryHandler.GetAsync(findMerchantQuery).GetAwaiter();

            var merchant = result.GetResult();

            if (merchant is null)
                return Outcomes.Success();

            return Outcomes.Failure<int[]>().WithMessage($"Merchant ID is alredy in use!");
        }
    }
}
