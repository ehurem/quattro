using System.Collections.Generic;

namespace Quattro.Paging.Abstractions
{
    /// <summary>
    /// Represents paged list.
    /// </summary>
    /// <typeparam name="T">Paged list item type.</typeparam>
    public interface IPagedList<out T> : IEnumerable<T>
    {
        /// <summary>
        /// Paging instance.
        /// </summary>
        IPaging Paging { get; }

        /// <summary>
        /// Paged list indexing.
        /// </summary>
        /// <param name="index">Index inside list.</param>
        /// <returns>Element at index.</returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        T this[int index] { get; }

        /// <summary>
        /// Total number of elements in paged list.
        /// </summary>
        /// <returns>Total count.</returns>
        int Count();

        /// <summary>
        /// Retrieves empty paged list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IPagedList<T> Empty();
    }
}
