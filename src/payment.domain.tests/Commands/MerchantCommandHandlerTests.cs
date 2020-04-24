namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Domain.commands.Merchants;
    using AG.PaymentApp.Domain.Commands;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using Ether.Outcomes;
    using FluentAssertions;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class MerchantCommandHandlerTests
    {
        private Guid merchantID = Guid.NewGuid();
        private Currency currency = Currency.Default;
        private Country country = Country.Default;

        private MerchantCommandHandler ReturnMerchantCommandHandlerObject()
        {
            var mockMediatorHandler = new Mock<IMediatorHandler>();
            var mockIPaymentEventRepository = new Mock<IMerchantRepository>();
            var mockNotificationHandler = new Mock<DomainNotificationHandler>();

            var merchantCommandHandler = new MerchantCommandHandler(mockIPaymentEventRepository.Object,
                mockMediatorHandler.Object, mockNotificationHandler.Object);

            return merchantCommandHandler;
        }

        [Fact]
        public async Task HandleCommand_WithRaiseEvent_Success()
        {
            //ARRANGE
            var mockMerchantValidation = new Mock<ICommandValidation<MerchantCommand>>();
            mockMerchantValidation
                .Setup(p => p.ValidateCommand(It.IsAny<NewMerchantCommand>()))
                .Returns(Outcomes.Success());

            var newPaymentCommand = new NewMerchantCommand(merchantID, "Merchant Test", "Test", currency, country, true, true, mockMerchantValidation.Object);

            var merchantCommandHandler = ReturnMerchantCommandHandlerObject();

            //ACT
            var result = await merchantCommandHandler.Handle(newPaymentCommand, CancellationToken.None);

            //ASSERT
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HandleCommand_WithRaiseEvent_Validation_Error()
        {
            //ARRANGE
            var mockMerchantValidation = new Mock<ICommandValidation<MerchantCommand>>();
            mockMerchantValidation
                .Setup(p => p.ValidateCommand(It.IsAny<NewMerchantCommand>()))
                .Returns(Outcomes.Failure());

            var newPaymentCommand = new NewMerchantCommand(merchantID, "Merchant Test", "Test", currency, country, true, true, mockMerchantValidation.Object);

            var merchantCommandHandler = ReturnMerchantCommandHandlerObject();

            //ACT
            var result = await merchantCommandHandler.Handle(newPaymentCommand, CancellationToken.None);

            //ASSERT
            result.Should().BeFalse();
        }
    }
}
