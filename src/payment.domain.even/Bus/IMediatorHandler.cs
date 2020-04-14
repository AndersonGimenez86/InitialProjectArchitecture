// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMediatorHandler.cs" company="Farfetch">
//   Copyright (c) Farfetch. All rights reserved.
// </copyright>
// <summary>
// IMediatorHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Payment.Domain.Core.Bus
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Events;
    using Payment.Domain.Core.Commands;

    public interface IMediatorHandler<T, C> where T : Event where C : Command
    {
        Task SendCommand(C command);
        Task RaiseEvent(T @event);
    }
}
