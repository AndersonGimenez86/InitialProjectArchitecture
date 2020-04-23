using System.Threading;
using System.Threading.Tasks;
using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
using MediatR;

namespace AG.Payment.Domain.Events.Handlers
{
    public class PaymentEventHandler : INotificationHandler<PaymentRegisteredEvent>
    {
        private readonly ITopicProducer<PaymentRegisteredEvent> topicProducer;

        public PaymentEventHandler(ITopicProducer<PaymentRegisteredEvent> topicProducer)
        {
            this.topicProducer = topicProducer;
        }

        public async Task Handle(PaymentRegisteredEvent message, CancellationToken cancellationToken)
        {
            //produce event for acquiring bank consumes                
            var kafkaResponse = await this.topicProducer.ProduceAsync(message);

            //update payment status to processing
            //if (kafkaResponse.Success)
            //{
            //    payment.Status = PaymentStatus.Processing;
            //    await this.paymentCommand.UpdateAsync(payment);
            ////}

        }
    }
}
