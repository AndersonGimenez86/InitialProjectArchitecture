namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Domain.commands.Shoopers;
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using Ether.Outcomes;
    using FluentAssertions;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ShopperCommandHandlerTests
    {
        private Guid shopperID = Guid.NewGuid();
        private string email = "test@123.com";
        private string lastName = "Last Test";
        private string firstName = "Test";
        private DateTime birthDate = DateTime.Now.AddDays(-30000);
        private Address address = Address.Create(Guid.NewGuid(), "Test", "12", "Porto", "09090-123", "Portugal");

        private ShopperCommandHandler ReturnShopperCommandHandlerObject()
        {
            var mockMediatorHandler = new Mock<IMediatorHandler>();
            var mockIPaymentEventRepository = new Mock<IShopperRepository>();
            var mockNotificationHandler = new Mock<DomainNotificationHandler>();

            var shopperCommandHandler = new ShopperCommandHandler(mockIPaymentEventRepository.Object,
                mockMediatorHandler.Object, mockNotificationHandler.Object);

            return shopperCommandHandler;
        }

        [Fact]
        public async Task HandleCommand_WithRaiseEvent_Success()
        {
            //ARRANGE
            var mockShopperValidation = new Mock<ICommandValidation<ShopperCommand>>();
            mockShopperValidation
                .Setup(p => p.ValidateCommand(It.IsAny<NewShopperCommand>()))
                .Returns(Outcomes.Success());

            var newShopperCommand = new NewShopperCommand(shopperID, firstName, lastName, email, Gender.Men, address, birthDate, mockShopperValidation.Object);

            var shopperCommandHandler = ReturnShopperCommandHandlerObject();

            //ACT
            var result = await shopperCommandHandler.Handle(newShopperCommand, CancellationToken.None);

            //ASSERT
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HandleCommand_WithRaiseEvent_Validation_Error()
        {
            //ARRANGE
            var mockShopperValidation = new Mock<ICommandValidation<ShopperCommand>>();
            mockShopperValidation
                .Setup(p => p.ValidateCommand(It.IsAny<NewShopperCommand>()))
                .Returns(Outcomes.Failure());

            var newShopperCommand = new NewShopperCommand(shopperID, firstName, lastName, email, Gender.Men, address, birthDate, mockShopperValidation.Object);

            var shopperCommandHandler = ReturnShopperCommandHandlerObject();

            //ACT
            var result = await shopperCommandHandler.Handle(newShopperCommand, CancellationToken.None);

            //ASSERT
            result.Should().BeFalse();
        }
    }
}
