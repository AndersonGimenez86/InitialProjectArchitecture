namespace AG.PaymentApp.Application.Messaging.tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Messaging.Handlers;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.Kafka.Producers;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using AG.PaymentApp.Domain.ValueObject;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class BankEventHandlerTests
    {
        [Fact]
        public async Task Handle_ProduceBankResponseTransactionMessageAsync_Success()
        {
            // Arrange
            var createPaymentEvent = new CreatePaymentEvent(Guid.NewGuid(), Guid.NewGuid(), new CreditCardProtected(), Money.Zero);

            var createTransactionEvent = new CreateTransactionEvent(createPaymentEvent.EventID, Guid.NewGuid(), "Approved");

            var deliveryMessageReport = new DeliveryMessageReport("Payment.gateway-events-v2", DateTime.Now);

            var mockITopicProducer = new Mock<ITopicProducer<CreateTransactionEvent>>();
            mockITopicProducer.Setup(t => t.ProduceAsync(createTransactionEvent))
            .ReturnsAsync(deliveryMessageReport);

            // Act
            var bankEventHandler = new BankEventHandler(mockITopicProducer.Object);
            await bankEventHandler.HandleAsync(createPaymentEvent);

            // Assert
            mockITopicProducer.Verify(mock => mock.ProduceAsync(It.IsAny<CreateTransactionEvent>()), new Times());
        }
    }
}
