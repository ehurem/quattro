using Microsoft.EntityFrameworkCore;
using Quattro.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quattro.Persistence.EF
{
    public class DataRepository<TEntity> : ReadOnlyRepository<TEntity>, IDataRepository<TEntity>
        where TEntity : class
    {
        public DataRepository(DbContext context) : base(context)
        {

        }

        public async Task DeleteAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity != null)
                DbSet.Remove(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            if (entity != null)
                DbSet.Remove(entity);

            return Task.CompletedTask;
        }

        // TODO: Re-visit
        public async Task DeleteRangeAsync(IEnumerable<object> ids)
        {
            foreach (var id in ids)
            {
                var entity = await DbSet.FindAsync(id);

                if (entity != null)
                    DbSet.Remove(entity);
            }
        }

        public Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities != null)
                DbSet.RemoveRange(entities);

            return Task.CompletedTask;
        }

        public Task InsertAsync(TEntity entity)
        {
            return DbSet.AddAsync(entity);
        }

        public Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            return DbSet.AddRangeAsync(entities);
        }
    }
}
