// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="AG Software">
// Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// IUnitOfWork
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AG.PaymentApp.Domain.Interface
{
    public interface IUnitOfWork : IObserver<UnitOfWorkState>
    {
        /// <summary>
        /// Begins a parallel unit of work.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <param name="unitOfWorkIsolation">The unit of work isolation.</param>
        /// <returns></returns>
        IUnitOfWork BeginParallelUnitOfWork(string connectionStringName, UnitOfWorkIsolation unitOfWorkIsolation);

        /// <summary>
        /// Begins a new unit of work with the default isolation.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <returns></returns>
        IUnitOfWork BeginUnitOfWork(string connectionStringName);

        /// <summary>
        /// Begins a new unit of work with the specified isolation.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <param name="unitOfWorkIsolation">The unit of work isolation.</param>
        /// <returns></returns>
        IUnitOfWork BeginUnitOfWork(string connectionStringName, UnitOfWorkIsolation unitOfWorkIsolation);
    }
