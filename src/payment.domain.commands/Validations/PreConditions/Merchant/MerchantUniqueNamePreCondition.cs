namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Merchant
{
    using System.Collections.Generic;
    using System.Linq;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using Ether.Outcomes;

    public class MerchantUniqueNamePreCondition : IPreCondition<MerchantCommand>
    {
        private readonly IFindMerchantRepository findMerchantRepository;

        public MerchantUniqueNamePreCondition(IFindMerchantRepository findMerchantRepository)
        {
            this.findMerchantRepository = findMerchantRepository;
        }

        public IOutcome Accept(MerchantCommand newEntity)
        {
            var findMerchantQuery = new FindMerchantQuery(newEntity.Name);

            var task = this.findMerchantRepository.GetAllAsync(findMerchantQuery).GetAwaiter();
            IEnumerable<Merchant> merchant = task.GetResult();

            if (merchant is null || !merchant.Any())
                return Outcomes.Success();

            return Outcomes.Failure<int[]>().WithMessage($"Merchant name is alredy in use!");
        }
    }
}
