using Microsoft.EntityFrameworkCore;
using Quattro.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quattro.Persistence.EF
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>, IPagedRepository<TEntity>
        where TEntity : class
    {
        protected DbContext Context { get; }

        protected IQueryable<TEntity> QuerySet => DbSet;

        protected DbSet<TEntity> DbSet { get; }

        public ReadOnlyRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await QuerySet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = QuerySet;

            includeProperties = includeProperties?.Where(ip => ip != null).ToArray() ?? Enumerable.Empty<Expression<Func<TEntity, object>>>().ToArray();

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties)
        {
            var query = QuerySet;

            includeProperties = includeProperties?.Where(ip => !string.IsNullOrWhiteSpace(ip)).ToArray() ?? Enumerable.Empty<string>().ToArray();

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification)
        {
            return await GetAsyncCore<TEntity>(specification, (entity) => entity);
        }

        public async Task<IEnumerable<TResult>> GetAsync<TResult>(ISpecification<TEntity> specification, Expression<Func<TEntity, TResult>> selector)
        {
            return await GetAsyncCore<TResult>(specification, selector);
        }

        private async Task<IEnumerable<TResult>> GetAsyncCore<TResult>(ISpecification<TEntity> specification, Expression<Func<TEntity, TResult>> selector)
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            var query = QuerySet;

            if (specification.Includes.Any())
            {
                var includeProperties = specification.Includes?.Where(ip => ip != null).ToArray() ?? Enumerable.Empty<Expression<Func<TEntity, object>>>().ToArray();

                foreach (var includeProperty in includeProperties)
                    query = query.Include(includeProperty);
            }
            else if (specification.IncludeStrings.Any())
            {
                var includeProperties = specification.IncludeStrings?.Where(ip => !string.IsNullOrWhiteSpace(ip)).ToArray() ?? Enumerable.Empty<string>().ToArray();

                foreach (var includeProperty in includeProperties)
                    query = query.Include(includeProperty);
            }

            if (specification.Predicate != null)
                query = query.Where(specification.Predicate);

            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending != null)
                query = query.OrderByDescending(specification.OrderByDescending);

            var result = query.Select(selector);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = QuerySet;

            includeProperties = includeProperties?.Where(ip => ip != null).ToArray() ?? Enumerable.Empty<Expression<Func<TEntity, object>>>().ToArray();

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            query = query.Where(predicate);

            var result = query.Select(selector);

            return await result.ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            return DbSet.FindAsync(id);
        }

        public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return QuerySet.FirstOrDefaultAsync(predicate);
        }
    }
}
