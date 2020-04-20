namespace AG.PaymentApp.Repository.Interface
{
    using AG.PaymentApp.Domain.Entity.Mongo;

    public interface IPaymentRepositoryStartup : IRepositoryStartup<PaymentMongo>
    {
    }
}
