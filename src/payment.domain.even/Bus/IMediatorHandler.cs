// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMediatorHandler.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// IMediatorHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AG.Payment.Domain.Core.Bus
{
    using System.Threading.Tasks;
    using AG.Payment.Domain.Core.Commands;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.Kafka.Producers.Interface;

    public interface IMediatorHandler
    {
        Task SendCommand<C>(C command) where C : Command;
        Task RaiseEvent<E>(E @event);
        Task RaiseEvent<E>(E @event, ITopicProducer<E> topicProducer) where E : Event;
    }
}
