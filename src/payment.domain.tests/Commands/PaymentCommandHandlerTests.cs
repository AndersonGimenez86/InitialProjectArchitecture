namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using AG.PaymentApp.Domain.Entity.Mongo;
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

            //var newPaymentCommand = new NewPaymentCommand(paymentID, shopperID, merchantID, default(CreditCard), default(Money), null);

            //var mockIPaymentEventRepository = new Mock<IPaymentEventRepository>();
            //mockIPaymentEventRepository.Setup(r => r.SaveAsync(newPaymentCommand));

            //var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new PaymentProfile()));
            //var mapper = mapperConfiguration.CreateMapper();

            //var paymentCommandHandler = new PaymentCommandHandler(mockIPaymentEventRepository.Object, mapper);

            ////ACT
            //var result = paymentCommandHandler.Handle(newPaymentCommand);

            //ASSERT
            //result.Exception.Should().BeNull();
        }
    }
}
