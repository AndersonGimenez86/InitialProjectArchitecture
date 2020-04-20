namespace AG.PaymentApp.repository.Interface
{
    using MongoDB.Driver;
    public interface IRepositoryStartup<T>
    {
        IMongoCollection<T> GetMongoCollection();

    }
}
