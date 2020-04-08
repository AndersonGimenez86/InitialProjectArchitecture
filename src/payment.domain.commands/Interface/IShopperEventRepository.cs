namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands.Shoppers;

    public interface IShopperEventRepository : IEventRepository<ShopperDataCommand>
    {
        Task SaveAsync(ShopperDataCommand eventData);

    }
}
