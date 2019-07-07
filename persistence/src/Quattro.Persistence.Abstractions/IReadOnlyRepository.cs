using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quattro.Persistence.Abstractions
{
    /// <summary>
    /// Read-only repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Retrieves entity by specified id. If entity does not exist then default value is retrieved.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// Retrieves single entity that satisfies specified predicate.
        /// If there is no entity that satisfies specified predicate then default is retrieved.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <returns></returns>
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retrieves collection of entities that satisfy specified predicate. If no such entities then empty collection is retrieved.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retrieves collection of entities that satisfy specified predicate. If no such entities then empty collection is retrieved.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <param name="includeProperties">Entity's properties to include in result.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Retrieves collection of entities that satisfy specified predicate. If no such entities then empty collection is retrieved.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <param name="includeProperties">Entity's properties to include in result.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties);

        /// <summary>
        /// Retrieves collection of entities that satisfy specified specification.
        /// If no such entities then empty collection is retrieved.
        /// </summary>
        /// <param name="specification">Specification with predicate, order clause, paging and include properties.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification);


        /// <summary>
        /// Retrieves collection of <see cref="TResult"/> that satisfy specified specification.
        /// If no such entities then empty collection is retrieved.
        /// </summary>
        /// <param name="specification">Specification with predicate, order clause, paging and include properties.</param>
        /// <param name="selector">Selector.</param>
        /// <returns></returns>
        Task<IEnumerable<TResult>> GetAsync<TResult>(ISpecification<TEntity> specification, Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// Retrieves collection of data of type <see cref="TResult"/> that satisfy specified predicate.
        /// If no such data then empty collection is retrieved.
        /// </summary>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="predicate">Predicate.</param>
        /// <param name="selector">Selector.</param>
        /// <param name="includeProperties">Entity's properties to include in result.</param>
        /// <returns></returns>
        Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includeProperties);
    }

}
