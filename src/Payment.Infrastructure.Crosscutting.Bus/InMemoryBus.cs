namespace AG.Payment.Infrastructure.Crosscutting.Bus
{
    using System.Threading.Tasks;
    using AG.Payment.Domain.Core.Bus;
    using AG.Payment.Domain.Core.Commands;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.Events.Interface;
    using MediatR;

    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore,
            IMediator mediator
            )
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task SendCommand<C>(C command) where C : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<E>(E @event) where E : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }
    }
}
