namespace AG.Payment.Infrastructure.Crosscutting.Bus
{
    using System.Threading.Tasks;
    using AG.Payment.Domain.Core.Bus;
    using AG.Payment.Domain.Core.Commands;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.Events.Interface;
    using AG.PaymentApp.Domain.Core.Kafka.Producers;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using MediatR;

    public sealed class InMemoryBus<EKafka> : IMediatorHandler where EKafka : Event
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        private readonly ITopicProducer<EKafka> topicProducer;

        public InMemoryBus(IEventStore eventStore,
            IMediator mediator,
            ITopicProducer<EKafka> topicProducer
            )
        {
            _eventStore = eventStore;
            _mediator = mediator;
            this.topicProducer = topicProducer;
        }

        public Task SendCommand<C>(C command) where C : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<E>(E @event) where E : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                var deliveryMessageReport = PublishKafkaMessage(@event).Result;
                return _mediator.Publish(deliveryMessageReport);
            }

            return _mediator.Publish(@event);
        }

        private async Task<DeliveryMessageReport> PublishKafkaMessage(Event @event)
        {
            //produce event for acquiring bank consumes                
            return await this.topicProducer.ProduceAsync(@event as EKafka);
        }
    }
}
