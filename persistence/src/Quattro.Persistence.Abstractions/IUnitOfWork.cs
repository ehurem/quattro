using System;
using System.Threading.Tasks;

namespace Quattro.Persistence.Abstractions
{
    /// <summary>
    /// Unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all tracked changes.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();

        /// <summary>
        /// Saves all tracked changes.
        /// </summary>
        /// <returns></returns>
        int Save();
    }
}
