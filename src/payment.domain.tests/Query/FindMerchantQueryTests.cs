namespace AG.PaymentApp.Domain.tests.Query
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.Query.Merchants;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class FindMerchantQueryTests
    {
        [Fact]
        public async Task ExecuteAsync_GetFromMongoDB()
        {
            //ARRANGE
            var merchantID = Guid.NewGuid();
            var merchantMongo = new MerchantMongo
            {
                Acronym = "Test",
                Country = "United Kingdom",
                Currency = "EUR",
                DateCreated = DateTime.Now,
                IsOnline = true,
                IsVisible = true,
                MerchantID = merchantID,
                Name = "Merchant Test"
            };

            var expectedMerchant = new Merchant
            {
                Acronym = "Test",
                Country = ValueObject.Country.Default,
                Currency = ValueObject.Currency.Default,
                DateCreated = DateTime.Now,
                IsOnline = true,
                IsVisible = true,
                Id = merchantID,
                Name = "Merchant Test"
            };

            var findMerchantQuery = new FindMerchantQuery(merchantID, string.Empty, string.Empty);

            //var mockIFindMerchantEventRepository = new Mock<IFindMerchantRepository>();
            //mockIFindMerchantEventRepository.Setup(r => r.GetAsync(findMerchantQuery))
            //    .ReturnsAsync(merchantMongo);

            //var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new MerchantProfile()));
            //var mapper = mapperConfiguration.CreateMapper();

            //var mockIAdaptMongoEntityToEntity = new Mock<IAdaptMongoEntityToEntity<MerchantMongo, Merchant>>();
            //mockIAdaptMongoEntityToEntity.Setup(a => a.Adapt(merchantMongo, mapper));

            //var findMerchantQueryHandler = new FindMerchantQueryHandler(mockIFindMerchantEventRepository.Object, mockIAdaptMongoEntityToEntity.Object, mapper);

            ////ACT
            //var result = findMerchantQueryHandler.GetAsync(findMerchantQuery);

            ////ASSERT
            //result.Result.Should().NotBeNull();
            //result.Result.Acronym.Should().BeEquivalentTo(expectedMerchant.Acronym);
            //result.Result.Country.Name.Should().BeEquivalentTo(expectedMerchant.Country.Name);
            //result.Result.Currency.Name.Should().BeEquivalentTo(expectedMerchant.Currency.Name);
            //result.Result.IsOnline.Should().BeTrue();
            //result.Result.IsVisible.Should().BeTrue();
            //result.Result.Name.Should().BeEquivalentTo(expectedMerchant.Name);
            //result.Result.Id.Should().Equals(expectedMerchant.Id);
        }
    }
}

