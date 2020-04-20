namespace AG.PaymentApp.repository.Startup
{
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.repository.Interface;
    using MongoDB.Driver;

    public class EventPaymentRepositoryStartup : IPaymentRepositoryStartup
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
