// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Command.cs" company="Farfetch">
//   Copyright (c) Farfetch. All rights reserved.
// </copyright>
// <summary>
// Command
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Payment.Domain.Core.Commands
{
    using System;
    using AG.PaymentApp.Domain.Core.Events;
    using FluentValidation.Results;

    public abstract class Command : Message
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract void IsValid();
    }
}
