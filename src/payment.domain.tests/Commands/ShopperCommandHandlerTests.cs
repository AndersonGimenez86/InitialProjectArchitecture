namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.Domain.commands.Mapper;
    using AG.PaymentApp.Domain.commands.Shoopers;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.ValueObject;
    using AG.PaymentApp.repository.commands.Interface;
    using FluentAssertions;
    using Moq;
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

            var shopperDataCommand = new ShopperDataCommand(shopperMongo);

            var mockIShopperEventRepository = new Mock<IShopperEventRepository>();
            mockIShopperEventRepository.Setup(r => r.SaveAsync(shopperDataCommand));

            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new ShopperProfile()));
            var mapper = mapperConfiguration.CreateMapper();

            var shopperCommandHandler = new ShopperCommandHandler(mockIShopperEventRepository.Object, mapper);

            //ACT
            var result = shopperCommandHandler.ExecuteAsync(shopper);

            //ASSERT
            result.Exception.Should().BeNull();
        }
    }
}
