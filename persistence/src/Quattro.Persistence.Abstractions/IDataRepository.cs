using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quattro.Persistence.Abstractions
{
    /// <summary>
    /// Data repository.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDataRepository<TEntity> : IPagedRepository<TEntity>, IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Inserts specified entity.
        /// </summary>
        /// <param name="entity">Entity to insert.</param>
        /// <returns></returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Inserts specified collection of entities.
        /// </summary>
        /// <param name="entities">Entities to insert.</param>
        /// <returns></returns>
        Task InsertRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes entity with specified id.
        /// </summary>
        /// <param name="id">Entity's id.</param>
        /// <returns></returns>
        Task DeleteAsync(object id);

        /// <summary>
        /// Deletes specified entity.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Deletes collection of entities with specified ids.
        /// </summary>
        /// <param name="ids">Ids of entities to delete.</param>
        /// <returns></returns>
        Task DeleteRangeAsync(IEnumerable<object> ids);

        /// <summary>
        /// Deletes collection of entities.
        /// </summary>
        /// <param name="entities">Entities to delete.</param>
        /// <returns></returns>
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
