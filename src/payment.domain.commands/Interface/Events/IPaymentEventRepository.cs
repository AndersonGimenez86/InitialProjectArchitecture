namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Interface;

    public interface IPaymentEventRepository : IRepository<PaymentCommand>
    {
        Task SaveAsync(PaymentCommand eventData);
        Task UpdateAsync(PaymentCommand eventData);
    }
}
