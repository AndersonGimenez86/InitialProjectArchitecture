namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Commands.Mapper;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using AutoMapper;
    using Ether.Outcomes;
    using FluentAssertions;
    using Microsoft.AspNetCore.DataProtection;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class PaymentCommandHandlerTests
    {
        [Fact]
        public async Task HandleCommand_WithRaiseEvent_Success()
        {
            //ARRANGE
            var merchantID = Guid.NewGuid();
            var creditCardID = Guid.NewGuid();
            var shopperID = Guid.NewGuid();
            var paymentID = Guid.NewGuid();
            var money = Money.Zero;
            var creditCard = new CreditCard()
            {
                CreditCardID = creditCardID,
                CreditCardType = Core.Enum.CreditCardType.Amex,
                CVV = 123,
                ExpireDate = DateTime.Now.AddDays(10),
                Number = "1234 5678 9012 3456",
                Owner = "Test"
            };

            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new PaymentProfile()));
            var mockPaymentValidation = new Mock<ICommandValidation<PaymentCommand>>();
            var mockMediatorHandler = new Mock<IMediatorHandler>();
            var mockDataProtectionProvider = new Mock<IDataProtectionProvider>();
            var mockDataProtector = new Mock<IDataProtector>();
            var mockIPaymentEventRepository = new Mock<IPaymentRepository>();
            var mockNotificationHandler = new Mock<DomainNotificationHandler>();

            var newPaymentCommand = new NewPaymentCommand(paymentID, shopperID,
                merchantID, creditCard, money,
                mockPaymentValidation.Object);

            var paymentCommandHandler = new PaymentCommandHandler(mockIPaymentEventRepository.Object,
                mockMediatorHandler.Object, mockDataProtectionProvider.Object, mockNotificationHandler.Object);

            mockPaymentValidation
                .Setup(p => p.ValidateCommand(newPaymentCommand))
                .Returns(Outcomes.Success());

            mockDataProtectionProvider
                .Setup(dp => dp.CreateProtector(It.IsAny<string>()))
                .Returns(mockDataProtector.Object);

            mockDataProtector
                .Setup(sut => sut.Protect(It.IsAny<byte[]>()))
                .Returns(Encoding.UTF8.GetBytes("protectedText"));

            //ACT
            var result = await paymentCommandHandler.Handle(newPaymentCommand, CancellationToken.None);

            //ASSERT
            result.Should().BeTrue();
        }
    }
}
