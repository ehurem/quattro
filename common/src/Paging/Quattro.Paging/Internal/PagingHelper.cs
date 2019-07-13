using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Quattro.Paging.Abstractions;

namespace Quattro.Paging.Internal
{
    /// <summary>
    /// Paging helper.
    /// </summary>
    internal class PagingHelper
    {
        /// <summary>
        /// Retrieves paged list based on current page and records per page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Source.</param>
        /// <param name="page">Current page.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <returns>Paged list.</returns>
        public static IPagedList<T> GetPagedList<T>(IEnumerable<T> source, int page, int recordsPerPage)
        {
            return DoPaging(source?.AsQueryable(), page, recordsPerPage);
        }

        /// <summary>
        /// Filters and then retrieves paged list based on current page and records per page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Source.</param>
        /// <param name="predicate">Predicate used to filter collection.</param>
        /// <param name="page">Current page.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <returns></returns>
        public static IPagedList<T> GetPagedList<T>(IEnumerable<T> source, Func<T, bool> predicate, int page,
            int recordsPerPage)
        {
            return ToPagedList(source, predicate, null, null, page, recordsPerPage);
        }

        /// <summary>
        /// Retrieves paged list based on current page and records per page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Source.</param>
        /// <param name="page">Current page.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <returns>Paged list.</returns>
        public static IPagedList<T> GetPagedList<T>(IQueryable<T> source, int page, int recordsPerPage)
        {
            return DoPaging(source, page, recordsPerPage);
        }

        /// <summary>
        /// Filters and then retrieves paged list based on current page and records per page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Source.</param>
        /// <param name="predicate">Predicate used to filter collection.</param>
        /// <param name="page">Current page.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <returns></returns>
        public static IPagedList<T> GetPagedList<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, int page,
            int recordsPerPage)
        {
            return ToPagedList(source, predicate, null, null, page, recordsPerPage);
        }

        #region Helpers

        private static IPagedList<T> ToPagedList<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate,
            string orderBy, bool? ascending, int page, int recordsPerPage)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate != null)
                source = source.Where(predicate);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
            }

            return DoPaging(source, page, recordsPerPage);
        }

        private static IPagedList<T> ToPagedList<T>(IEnumerable<T> source, Func<T, bool> predicate,
            string orderBy, bool? ascending, int page, int recordsPerPage)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate != null)
                source = source.Where(predicate);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {

            }

            return DoPaging(source.AsQueryable(), page, recordsPerPage);
        }

        private static IPagedList<T> DoPaging<T>(IQueryable<T> source, int page, int recordsPerPage)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            page = page < 1 ? 1 : page;
            recordsPerPage = recordsPerPage < 1 ? 1 : recordsPerPage;

            var result = source.Skip((page - 1) * recordsPerPage).Take(recordsPerPage);
            var paging = new PagingBase(page, recordsPerPage, source.Count());

            return new PagedList<T>(result.ToList(), paging);
        }

        #endregion
    }
}
