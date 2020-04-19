namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands;
    using AG.PaymentApp.Domain.Interface;

    public interface IMerchantRepository : IRepository<MerchantCommand>
    {
        Task SaveAsync(MerchantCommand merchantCommand);
    }
}
