// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Command.cs" company="Farfetch">
//   Copyright (c) Farfetch. All rights reserved.
// </copyright>
// <summary>
// Command
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Payment.Domain.Core.Commands
{
    public abstract class Command
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
