namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.Domain.commands.Mapper;
    using AG.PaymentApp.Domain.commands.Payments;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.ValueObject;
    using AG.PaymentApp.repository.commands.Interface;
    using FluentAssertions;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class PaymentCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_PersisteMongoDB()
        {
            //ARRANGE
            var merchantID = Guid.NewGuid();
            var creditCardID = Guid.NewGuid();
            var shopperID = Guid.NewGuid();
            var paymentID = Guid.NewGuid();

            var paymentMongo = new PaymentMongo
            {
                Amount = default(Money),
                CreditCard = default(CreditCardProtected),
                EventName = "Total Payment",
                PaymentID = paymentID,
                Reference = null,
                ShopperID = shopperID,
                Status = PaymentStatus.Approved,
                DateCreated = DateTime.Now,
                MerchantID = merchantID
            };

            var payment = new Payment
            {
                Amount = default(Money),
                CreditCard = default(CreditCardProtected),
                ID = paymentID,
                Reference = null,
                ShopperID = shopperID,
                Status = PaymentStatus.Approved,
                DateCreated = DateTime.Now,
                MerchantID = merchantID
            };

            var paymentDataCommand = new PaymentDataCommand(paymentMongo);

            var mockIPaymentEventRepository = new Mock<IPaymentEventRepository>();
            mockIPaymentEventRepository.Setup(r => r.SaveAsync(paymentDataCommand));

            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new PaymentProfile()));
            var mapper = mapperConfiguration.CreateMapper();

            var paymentCommandHandler = new PaymentCommandHandler(mockIPaymentEventRepository.Object, mapper);

            //ACT
            var result = paymentCommandHandler.ExecuteAsync(payment);

            //ASSERT
            result.Exception.Should().BeNull();
        }
    }
}
