namespace AG.Payment.Data.EventSourcing.Interface
{
    using MongoDB.Driver;
    public interface IRepositoryStartup<T>
    {
        IMongoCollection<T> GetMongoCollection();

    }
}
