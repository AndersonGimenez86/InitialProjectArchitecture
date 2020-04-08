namespace AG.PaymentApp.Domain.Query.Interface
{
    using System.Threading.Tasks;

    public interface IQueryHandler<in TQuery, TResult>
      where TQuery : IQuery
      where TResult : class
    {
        Task<TResult> GetAsync(TQuery query);
    }
}
