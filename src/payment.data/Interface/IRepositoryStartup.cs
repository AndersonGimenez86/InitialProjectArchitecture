namespace AG.PaymentApp.Data.Interface
{
    using MongoDB.Driver;
    public interface IRepositoryStartup<T>
    {
        IMongoCollection<T> GetMongoCollection();

    }
}
