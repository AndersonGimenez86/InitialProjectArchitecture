namespace Payment.domain.services.Validations.PreConditions.Merchant
{
    using System.Collections.Generic;
    using System.Linq;
    using Payment.domain.Entity.Merchants;
    using Payment.domain.query.Interface;
    using Payment.domain.query.Merchants;
    using Payment.domain.services.Validations.Interface;
    using Ether.Outcomes;

    public class MerchantUniqueNamePreCondition : IPreCondition<Merchant>
    {
        private readonly IFindMerchantQueryHandler findMerchantQueryHandler;

        public MerchantUniqueNamePreCondition(IFindMerchantQueryHandler findMerchantQueryHandler)
        {
            this.findMerchantQueryHandler = findMerchantQueryHandler;
        }

        public IOutcome Accept(Merchant newEntity)
        {
            var findMerchantQuery = new FindMerchantQuery(newEntity.Name);

            var task = this.findMerchantQueryHandler.GetAllAsync(findMerchantQuery).GetAwaiter();
            IEnumerable<Merchant> merchant = task.GetResult();

            if (merchant is null || !merchant.Any())
                return Outcomes.Success();

            return Outcomes.Failure<int[]>().WithMessage($"Merchant name is alredy in use!");
        }
    }
}
