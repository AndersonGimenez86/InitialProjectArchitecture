namespace AG.PaymentApp.repository.Startup
{
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.repository.Interface;
    using MongoDB.Driver;

    public class EventShopperRepositoryStartup : IEventShopperRepositoryStartup
    {
        private readonly IMongoRepository mongoRepository;

        public EventShopperRepositoryStartup(IMongoRepository mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public IMongoCollection<ShopperMongo> GetMongoCollection()
        {
            var fullyQualifiedTypeName = typeof(ShopperMongo).FullName;

            if (this.mongoRepository.CollectionNames.TryGetValue(fullyQualifiedTypeName, out string collectionName))
            {
                return mongoRepository.Database.GetCollection<ShopperMongo>(collectionName);
            }

            return null;
        }
    }
}
