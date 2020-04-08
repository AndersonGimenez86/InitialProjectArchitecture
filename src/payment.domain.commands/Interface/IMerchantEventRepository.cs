namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands;

    public interface IMerchantEventRepository : IEventRepository<MerchantDataCommand>
    {
        Task SaveAsync(MerchantDataCommand eventData);
    }
}
