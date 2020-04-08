namespace AG.PaymentApp.repository.Interface
{
    using AG.PaymentApp.Domain.events;

    public interface IEventShopperRepositoryStartup : IEventRepositoryStartup<ShopperMongo>
    {
    }
}
