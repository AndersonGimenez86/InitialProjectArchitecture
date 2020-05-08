namespace AG.PaymentApp.Data.Startup
{
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AG.PaymentApp.Domain.Interface;
    using AG.PaymentApp.Data.Interface;
    using MongoDB.Driver;

    public class EventMerchantRepositoryStartup : IMerchantRepositoryStartup
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
