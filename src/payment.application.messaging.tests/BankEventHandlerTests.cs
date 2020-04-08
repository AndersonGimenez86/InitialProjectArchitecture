namespace AG.PaymentApp.application.messaging.tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.messaging.Events;
    using AG.PaymentApp.application.messaging.Handlers;
    using AG.PaymentApp.crosscutting.kafka.Messaging.Producers.Interface;
    using AG.PaymentApp.Domain.ValueObject;
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config.Producers;
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
            mockITopicProducer.Setup(t => t.ProduceAsync("2123124", createTransactionEvent))
            .ReturnsAsync(deliveryMessageReport);

            // Act
            var bankEventHandler = new BankEventHandler(mockITopicProducer.Object);
            await bankEventHandler.HandleAsync(createPaymentEvent);

            // Assert
            mockITopicProducer.Verify(mock => mock.ProduceAsync(It.IsAny<string>(), It.IsAny<CreateTransactionEvent>()), new Times());
        }
    }
}
