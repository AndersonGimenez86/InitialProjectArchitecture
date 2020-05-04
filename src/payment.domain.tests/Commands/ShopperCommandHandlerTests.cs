﻿namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ShopperCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_PersisteMongoDB()
        {
            //ARRANGE
            var ShopperID = Guid.NewGuid();
            var email = "test@123.com";
            var lastName = "Last Test";
            var firstName = "Test";
            var shopperID = Guid.NewGuid();
            var creditCardID = Guid.NewGuid();
            var addressID = Guid.NewGuid();

            var address = Address.Create(addressID, "Test", "12", "Porto", "09090-123", "Portugal");

            var addressMongo = AddressMongo.Create(addressID, "Test", "12", "Porto", "09090-123", "Portugal", DateTime.Now);

            var shopperMongo = ShopperMongo.CreateNew(Gender.Men, shopperID, firstName, lastName, email, addressMongo);

            var shopper = Shopper.CreateNew(Gender.Men, shopperID, firstName, lastName, email);
            shopper.SetAddress(address);

            //var shopperDataCommand = new ShopperCommand(shopperMongo);

            //var mockIShopperEventRepository = new Mock<IShopperRepository>();
            //mockIShopperEventRepository.Setup(r => r.SaveAsync(shopperDataCommand));

            //var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new ShopperProfile()));
            //var mapper = mapperConfiguration.CreateMapper();

            //var shopperCommandHandler = new ShopperCommandHandler(mockIShopperEventRepository.Object, mapper, null, null, null);

            ////ACT
            //var result = shopperCommandHandler.ExecuteAsync(shopper);

            ////ASSERT
            //result.Exception.Should().BeNull();
        }
    }
}
