namespace AG.PaymentApp.Repository.Interface
{
    using MongoDB.Driver;
    public interface IRepositoryStartup<T>
    {
        IMongoCollection<T> GetMongoCollection();

    }
}
