namespace AG.PaymentApp.Data.Interface
{
    using AG.PaymentApp.Domain.Entity.Mongo;

    public interface IMerchantRepositoryStartup : IRepositoryStartup<MerchantMongo>
    {
    }
}
