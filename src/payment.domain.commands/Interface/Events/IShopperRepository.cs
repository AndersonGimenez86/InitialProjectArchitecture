namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Interface;

    public interface IShopperRepository : IRepository<ShopperCommand>
    {
        Task SaveAsync(ShopperCommand eventData);

    }
}
