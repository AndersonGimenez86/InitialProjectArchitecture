namespace AG.PaymentApp.Domain.Core.Events
{
    using System;
    using MediatR;

    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}