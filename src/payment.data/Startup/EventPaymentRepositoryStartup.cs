namespace AG.PaymentApp.Data.Startup
{
    using AG.PaymentApp.Data.Interface;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AG.PaymentApp.Domain.Interface;
    using MongoDB.Driver;

    public class EventPaymentRepositoryStartup : IRepositoryStartup<PaymentMongo>
    {
        private readonly IMongoRepository mongoRepository;

        public EventPaymentRepositoryStartup(IMongoRepository mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public IMongoCollection<PaymentMongo> GetMongoCollection()
        {
            var fullyQualifiedTypeName = typeof(PaymentMongo).FullName;

            if (this.mongoRepository.CollectionNames != null && this.mongoRepository.CollectionNames.TryGetValue(fullyQualifiedTypeName, out string collectionName))
            {
                return mongoRepository.Database.GetCollection<PaymentMongo>(collectionName);
            }

            return null;
        }
    }
}
