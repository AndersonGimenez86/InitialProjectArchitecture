namespace AG.PaymentApp.Application.Messaging.Handlers
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using AG.PaymentApp.Domain.Events;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging;

    public class BankEventHandler : IMessageHandler<CreatePaymentEvent>
    {
        private readonly ITopicProducer<CreateTransactionEvent> topicProducer;
        //private readonly ILogger logger;

        public BankEventHandler(ITopicProducer<CreateTransactionEvent> topicProducer)
        {
            this.topicProducer = topicProducer;
        }

        public async Task HandleAsync(CreatePaymentEvent message)
        {
            //TODO: implement logs
            var random = new Random();
            var minimumSeed = Convert.ToInt32((message.Amount.Value - (message.Amount.Value * Convert.ToDecimal(0.10))));
            var maximumSeed = Convert.ToInt32((message.Amount.Value + (message.Amount.Value * Convert.ToDecimal(0.30))));
            int randomShopperCreditCardLimit = random.Next(minimumSeed, maximumSeed);
            var newTransactionID = Guid.NewGuid();

            var transactionStatus = message.Amount.Value <= randomShopperCreditCardLimit ? "Approved" : "Rejected";

            var createTransactionEvent = new CreateTransactionEvent(message.EventID, newTransactionID, transactionStatus);

            var response = await this.topicProducer.ProduceAsync(createTransactionEvent);

            //TODO: Log response
        }
    }
}
