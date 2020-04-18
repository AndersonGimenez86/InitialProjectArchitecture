// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// Repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Payment.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using AG.PaymentApp.Domain.Interface;


    /// <summary>
    /// The base implementation for repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="Domain.Core.Repositories.IRepository{TEntity, TKey}"/>
    internal class RepositoryTemplate<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryTemplate{TEntity, TKey}"/> class.
        /// </summary>
        /// <param name="unitOfWorkManager">The unit of work manager.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected RepositoryTemplate(IUnitOfWorkManager unitOfWorkManager, string connectionStringName)
        {
            this.ConnectionStringName = connectionStringName;
            this.UnitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Gets the name of the connection string.
        /// </summary>
        /// <value>The name of the connection string.</value>
        protected string ConnectionStringName { get; private set; }

        /// <summary>
        /// Gets the unit of work manager.
        /// </summary>
        /// <value>The unit of work manager.</value>
        protected IUnitOfWorkManager UnitOfWorkManager { get; private set; }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public abstract Task AddAsync(TEntity entity);

        /// <summary>
        /// Adds or updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public abstract Task AddOrUpdateAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Adds or updates the specified entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract Task AddOrUpdateAsync(TEntity entity);

        /// <summary>
        /// Finds all entities using the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public abstract Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Finds the entity by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public abstract Task<TEntity> FindByKeyAsync(TKey key);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets all entities specifying conditions on an anonymous object.
        /// </summary>
        /// <param name="conditions">The conditions anonymous object.</param>
        /// <returns></returns>
        public abstract Task<IEnumerable<TEntity>> GetAllAsync(object conditions);

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public abstract Task RemoveAsync(TKey key);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public abstract Task UpdateAsync(TEntity entity);
    }
}
}
