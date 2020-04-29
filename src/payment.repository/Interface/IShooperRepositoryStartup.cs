namespace AG.Payment.Data.EventSourcing.Interface
{
    using AG.PaymentApp.Domain.Entity.Mongo;

    public interface IShopperRepositoryStartup : IRepositoryStartup<ShopperMongo>
    {
    }
}
