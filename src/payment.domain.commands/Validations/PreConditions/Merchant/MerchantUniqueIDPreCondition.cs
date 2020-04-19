namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Merchant
{
    using AG.PaymentApp.Domain.commands;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using Ether.Outcomes;

    public class MerchantUniqueIDPreCondition : IPreCondition<MerchantCommand>
    {
        private readonly IFindMerchantQueryHandler findMerchantQueryHandler;

        public MerchantUniqueIDPreCondition(IFindMerchantQueryHandler findMerchantQueryHandler)
        {
            this.findMerchantQueryHandler = findMerchantQueryHandler;
        }

        public IOutcome Accept(MerchantCommand newEntity)
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
