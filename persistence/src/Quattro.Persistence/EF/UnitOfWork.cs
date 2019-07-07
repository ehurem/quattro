using Microsoft.EntityFrameworkCore;
using Quattro.Persistence.Abstractions;
using System;
using System.Threading.Tasks;

namespace Quattro.Persistence.EF
{
    /// <summary>
    /// Base unit of work.
    /// </summary>
    public abstract class UnitOfWork : IUnitOfWork
    {
        private volatile bool _disposed;

        protected DbContext Context { get; }

        protected UnitOfWork(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public int Save()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch(Exception ex)
            {
                // TODO: Filter exceptions and throw custom exceptions.
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<int> SaveAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                // TODO: Filter exceptions and throw custom exceptions.
                throw;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
