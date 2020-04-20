namespace AG.PaymentApp.Repository.Startup
{
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.Interface;
    using AG.PaymentApp.Repository.Interface;
    using MongoDB.Driver;

    public class EventShopperRepositoryStartup : IShopperRepositoryStartup
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
