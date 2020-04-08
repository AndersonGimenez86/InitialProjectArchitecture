namespace AG.PaymentApp.repository.Startup
{
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.repository.Interface;
    using MongoDB.Driver;

    public class EventMerchantRepositoryStartup : IEventMerchantRepositoryStartup
    {
        private readonly IMongoRepository mongoRepository;

        public EventMerchantRepositoryStartup(IMongoRepository mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public IMongoCollection<MerchantMongo> GetMongoCollection()
        {
            var fullyQualifiedTypeName = typeof(MerchantMongo).FullName;

            if (this.mongoRepository.CollectionNames.TryGetValue(fullyQualifiedTypeName, out string collectionName))
            {
                return mongoRepository.Database.GetCollection<MerchantMongo>(collectionName);
            }

            return null;
        }
    }
}
