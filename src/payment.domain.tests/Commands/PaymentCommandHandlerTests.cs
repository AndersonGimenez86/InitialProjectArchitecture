namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.Payment.Domain.Core.Bus;
    using AG.Payment.Domain.Events;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using Ether.Outcomes;
    using FluentAssertions;
    using Microsoft.AspNetCore.DataProtection;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class PaymentCommandHandlerTests
    {
        private Guid merchantID = Guid.NewGuid();
        private Guid shopperID = Guid.NewGuid();
        private Guid paymentID = Guid.NewGuid();
        private Money money = Money.Zero;
        private CreditCard creditCard = new CreditCard()
        {
            CreditCardID = Guid.NewGuid(),
            CreditCardType = Core.Enum.CreditCardType.Amex,
            CVV = 123,
            ExpireDate = DateTime.Now.AddDays(10),
            Number = "1234 5678 9012 3456",
            Owner = "Test"
        };

        private PaymentCommandHandler ReturnPaymentCommandHandlerObject(Mock<IMediatorHandler> mockMediatorHandler)
        {
            var mockDataProtectionProvider = new Mock<IDataProtectionProvider>();
            var mockDataProtector = new Mock<IDataProtector>();
            var mockIPaymentEventRepository = new Mock<IPaymentRepository>();
            var mockNotificationHandler = new Mock<DomainNotificationHandler>();
            var mockTopicProducer = new Mock<ITopicProducer<PaymentRegisteredEvent>>();

            var paymentCommandHandler = new PaymentCommandHandler(mockIPaymentEventRepository.Object,
                mockMediatorHandler.Object, mockDataProtectionProvider.Object, mockTopicProducer.Object,
                mockNotificationHandler.Object);

            mockDataProtectionProvider
                .Setup(dp => dp.CreateProtector(It.IsAny<string>()))
                .Returns(mockDataProtector.Object);

            mockDataProtector
                .Setup(sut => sut.Protect(It.IsAny<byte[]>()))
                .Returns(Encoding.UTF8.GetBytes("protectedText"));

            return paymentCommandHandler;
        }

        [Fact]
        public async Task HandleCommand_WithRaiseEvent_Success()
        {
            //ARRANGE
            var mockMediatorHandler = new Mock<IMediatorHandler>();

            var mockPaymentValidation = new Mock<ICommandValidation<PaymentCommand>>();
            mockPaymentValidation
                .Setup(p => p.ValidateCommand(It.IsAny<NewPaymentCommand>()))
                .Returns(Outcomes.Success());

            var newPaymentCommand = new NewPaymentCommand(paymentID, shopperID,
              merchantID, creditCard, money,
              mockPaymentValidation.Object);

            var paymentCommandHandler = ReturnPaymentCommandHandlerObject(mockMediatorHandler);

            //ACT
            var result = await paymentCommandHandler.Handle(newPaymentCommand, CancellationToken.None);

            //ASSERT
            result.Should().BeTrue();
            mockMediatorHandler.Verify(m => m.RaiseEvent(It.IsAny<PaymentRegisteredEvent>()));
        }

        [Fact]
        public async Task HandleCommand_WithRaiseEvent_Validation_Error()
        {
            //ARRANGE
            var mockMediatorHandler = new Mock<IMediatorHandler>();

            var mockPaymentValidation = new Mock<ICommandValidation<PaymentCommand>>();
            mockPaymentValidation
                .Setup(p => p.ValidateCommand(It.IsAny<NewPaymentCommand>()))
                .Returns(Outcomes.Failure());

            var newPaymentCommand = new NewPaymentCommand(paymentID, shopperID,
              merchantID, creditCard, money,
              mockPaymentValidation.Object);

            var paymentCommandHandler = ReturnPaymentCommandHandlerObject(mockMediatorHandler);

            //ACT
            var result = await paymentCommandHandler.Handle(newPaymentCommand, CancellationToken.None);

            //ASSERT
            result.Should().BeFalse();
        }
    }
}
