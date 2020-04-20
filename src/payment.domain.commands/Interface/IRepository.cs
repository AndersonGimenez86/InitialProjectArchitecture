namespace AG.PaymentApp.Domain.Commands.Interface
{
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        Task SaveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
