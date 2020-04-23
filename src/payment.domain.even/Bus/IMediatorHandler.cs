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
    using AG.PaymentApp.Domain.Core.Events;
    using AG.Payment.Domain.Core.Commands;

    public interface IMediatorHandler
    {
        Task SendCommand<C>(C command) where C : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
