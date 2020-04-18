// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkIsolation.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// UnitOfWorkIsolation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AG.PaymentApp.Domain.Core.UnitOfWork
{
    public enum UnitOfWorkIsolation
    {
        /// <summary>
        /// The unspecified
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The chaos
        /// </summary>
        Chaos = 1,

        /// <summary>
        /// The read uncommitted
        /// </summary>
        ReadUncommitted = 2,

        /// <summary>
        /// The read committed
        /// </summary>
        ReadCommitted = 3,

        /// <summary>
        /// The repeatable read
        /// </summary>
        RepeatableRead = 4,

        /// <summary>
        /// The serializable
        /// </summary>
        Serializable = 5,

        /// <summary>
        /// The snapshot
        /// </summary>
        Snapshot = 6
    }
}
