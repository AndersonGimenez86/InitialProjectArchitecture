namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands;

    public interface IMerchantRepository : IRepository<MerchantDataCommand>
    {
        Task SaveAsync(MerchantDataCommand eventData);
    }
}
