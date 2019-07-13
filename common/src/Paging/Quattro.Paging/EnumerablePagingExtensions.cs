using System;
using System.Collections.Generic;
using Quattro.Paging.Abstractions;
using Quattro.Paging.Internal;

namespace Quattro.Paging
{
    /// <summary>
    /// Enumerable paging extensions.
    /// </summary>
    public static class EnumerablePagingExtensions
    {
        /// <summary>
        /// Retrieves paged list based on provided current page and records per page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="page">Current page.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <returns>Paged list.</returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int page, int recordsPerPage)
        {
            return PagingHelper.GetPagedList(source, page, recordsPerPage);
        }

        /// <summary>
        /// Filters list based on predicate and retrieves paged list based on provided current page and records per page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Source.</param>
        /// <param name="predicate">Predicate used to filter collection.</param>
        /// <param name="page">Current page.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <returns>Paged list.</returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, Func<T, bool> predicate, int page, int recordsPerPage)
        {
            return PagingHelper.GetPagedList(source, predicate, page, recordsPerPage);
        }
    }
}
