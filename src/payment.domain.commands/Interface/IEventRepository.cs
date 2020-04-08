namespace AG.PaymentApp.repository.commands.Interface
{
    using System.Threading.Tasks;

    public interface IEventRepository<T>
    {
        Task SaveAsync(T eventData);
    }
}
