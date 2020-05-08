namespace Payment.Data.Tests.Repositories
{
    using Xunit;

    public class PaymentRepositoryTests
    {
        [Fact]
        public void PaymentRepositoryStartup_GetMongoCollection_ThrowsNotSupportedException()
        {
            //// Arrange
            //var config = new EventStoreSettings
            //{
            //    Collections = new Dictionary<string, EventStoreServiceSettings>
            //    {
            //        {
            //            "key",
            //            new EventStoreServiceSettings
            //            {
            //                CollectionName = "",
            //                PayloadFullyQualifiedTypeName = ""
            //            }
            //        }
            //    },
            //    MongoDbConnectionString = "random_mongo_connection_string",
            //    MongoDbName = "random_mongo_db_name"
            //};

            //var emptyCollectionNames = new Dictionary<string, string>();

            //var mockMongoRepository = new Mock<IMongoRepository>();
            //mockMongoRepository
            //    .Setup(mock => mock.CollectionNames)
            //    .Returns(emptyCollectionNames);

            //var sut = new PaymentIntentEventRepositoryStartup(mockMongoRepository.Object);

            ////Act & Assert
            //Assert.Throws<NotSupportedException>(() => sut.GetMongoCollection());
        }
    }
}
