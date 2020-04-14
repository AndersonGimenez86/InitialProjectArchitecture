// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryBus.cs" company="Farfetch">
//   Copyright (c) Farfetch. All rights reserved.
// </copyright>
// <summary>
// InMemoryBus
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Payment.Infrastructure.Crosscutting.Bus
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.Kafka.Producers;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;
    using MediatR;
    using Payment.Domain.Core.Bus;
    using Payment.Domain.Core.Commands;

    public sealed class InMemoryBus<T, C> : IMediatorHandler<T, C> where T : Event where C : Command
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        private readonly ITopicProducer<T> topicProducer;

        public InMemoryBus(IEventStore eventStore,
            IMediator mediator,
            ITopicProducer<T> topicProducer

            )
        {
            _eventStore = eventStore;
            _mediator = mediator;
            this.topicProducer = topicProducer;

        }

        public Task SendCommand(C command)
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent(T @event)
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                var deliveryMessageReport = PublishKafkaMessage(@event).Result;
                return _mediator.Publish(deliveryMessageReport);

            }

            return _mediator.Publish(@event);
        }

        private async Task<DeliveryMessageReport> PublishKafkaMessage(T @event)
        {
            //produce event for acquiring bank consumes                
            return await this.topicProducer.ProduceAsync(@event);
        }
    }
}
