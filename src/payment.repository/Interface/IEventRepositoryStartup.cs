namespace AG.PaymentApp.repository.Interface
{
    using MongoDB.Driver;
    public interface IEventRepositoryStartup<T>
    {
        IMongoCollection<T> GetMongoCollection();

    }
}
