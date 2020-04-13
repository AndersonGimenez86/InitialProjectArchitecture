namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Payments;

    public interface IPaymentEventRepository : IEventRepository<PaymentCommand>
    {
        Task SaveAsync(PaymentCommand eventData);
        Task UpdateAsync(PaymentCommand eventData);
    }
}
