namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands.Payments;

    public interface IPaymentEventRepository : IEventRepository<PaymentDataCommand>
    {
        Task SaveAsync(PaymentDataCommand eventData);
        Task UpdateAsync(PaymentDataCommand eventData);
    }
}
