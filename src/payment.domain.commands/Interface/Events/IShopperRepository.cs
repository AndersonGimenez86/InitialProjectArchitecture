namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands.Shoppers;

    public interface IShopperRepository : IRepository<ShopperDataCommand>
    {
        Task SaveAsync(ShopperDataCommand eventData);

    }
}
