namespace AG.PaymentApp.repository.Interface
{
    using AG.PaymentApp.Domain.events;

    public interface IPaymentRepositoryStartup : IRepositoryStartup<PaymentMongo>
    {
    }
}
