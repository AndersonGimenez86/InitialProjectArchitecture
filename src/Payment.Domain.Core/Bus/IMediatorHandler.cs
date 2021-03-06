﻿namespace AG.Payment.Domain.Core.Bus
{
    using System.Threading.Tasks;
    using AG.Payment.Domain.Core.Commands;
    using AG.PaymentApp.Domain.Core.Events;

    public interface IMediatorHandler
    {
        Task SendCommand<C>(C command) where C : Command;
        Task RaiseEvent<E>(E @event) where E : Event;
    }
}
