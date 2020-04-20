// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryBus.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// InMemoryBus
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Payment.Infrastructure.Crosscutting.Bus
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.Events.Interface;
    using AG.PaymentApp.Domain.Core.Kafka.Producers;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using MediatR;
    using Payment.Domain.Core.Bus;
    using Payment.Domain.Core.Commands;

    public sealed class InMemoryBus<E> : IMediatorHandler where E : Event
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        private readonly ITopicProducer<E> topicProducer;

        public InMemoryBus(IEventStore eventStore,
            IMediator mediator,
            ITopicProducer<E> topicProducer

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

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                var deliveryMessageReport = PublishKafkaMessage(@event as E).Result;
                return _mediator.Publish(deliveryMessageReport);

            }

            return _mediator.Publish(@event);
        }

        private async Task<DeliveryMessageReport> PublishKafkaMessage(E @event)
        {
            //produce event for acquiring bank consumes                
            return await this.topicProducer.ProduceAsync(@event);
        }
    }
}
