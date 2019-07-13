using Quattro.Paging.Abstractions;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quattro.Persistence.Abstractions
{
    /// <summary>
    /// Paged repository.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IPagedRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Retrieves paged collection of entities that satisfy specified specification.
        /// If no such entities then empty paged collection is retrieved.
        /// </summary>
        /// <param name="specification">Paged specification.</param>
        /// <returns></returns>
        Task<IPagedList<TEntity>> GetPagedAsync(IPagedSpecification<TEntity> specification);

        /// <summary>
        /// Retrieves paged collection of <see cref="TResult"/> that satisfy specified specification.
        /// If no such entities then empty paged collection is retrieved.
        /// </summary>
        /// <param name="specification">Paged specification.</param>
        /// <param name="selector">Selector.</param>
        /// <returns></returns>
        Task<IPagedList<TResult>> GetPagedAsync<TResult>(IPagedSpecification<TEntity> specification, Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// Retrieves paged collection of entities that satisfy specified predicate.
        /// Paging is done based on specified page and page size.
        /// If no such entities then empty paged collection is retrieved.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Records per page.</param>
        /// <returns></returns>
        Task<IPagedList<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize);

        /// <summary>
        /// Retrieves paged collection of entities that satisfy specified predicate.
        /// Paging is done based on specified page and page size.
        /// If no such entities then empty paged collection is retrieved.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Records per page.</param>
        /// <param name="includeProperties">Entity's properties to include.</param>
        /// <returns></returns>
        Task<IPagedList<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize,
            params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Retrieves paged collection of data of type <see cref="TResult"/> that satisfy specified predicate.
        /// If no such data then empty paged collection is retrieved.
        /// </summary>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="predicate">Predicate.</param>
        /// <param name="selector">Selector.</param>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Records per page.</param>
        /// <returns></returns>
        Task<IPagedList<TResult>> GetPagedAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, int page, int pageSize);
    }
}
