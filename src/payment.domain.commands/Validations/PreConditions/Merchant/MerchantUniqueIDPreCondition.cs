namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Merchant
{
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.queries.Interface;
    using Ether.Outcomes;

    public class MerchantUniqueIDPreCondition : IPreCondition<MerchantCommand>
    {
        private readonly IFindMerchantRepository findMerchantRepository;

        public MerchantUniqueIDPreCondition(IFindMerchantRepository findMerchantRepository)
        {
            this.findMerchantRepository = findMerchantRepository;
        }

        public IOutcome Accept(MerchantCommand newEntity)
        {
            var result = this.findMerchantRepository.GetAsync(newEntity.Id).GetAwaiter();

            var merchant = result.GetResult();

            if (merchant is null)
                return Outcomes.Success();

            return Outcomes.Failure<int[]>().WithMessage($"Merchant ID is alredy in use!");
        }
    }
}
