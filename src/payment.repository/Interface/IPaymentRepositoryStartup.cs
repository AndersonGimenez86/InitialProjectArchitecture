namespace AG.PaymentApp.Repository.Interface
{
    using AG.PaymentApp.Domain.events;

    public interface IPaymentRepositoryStartup : IRepositoryStartup<PaymentMongo>
    {
    }
}
