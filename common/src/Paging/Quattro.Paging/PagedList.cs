using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Quattro.Paging.Abstractions;

namespace Quattro.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        readonly IList<T> _source;

        private PagedList() { }

        /// <summary>
        /// Creates new paged list instance.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="paging">Paging.</param>
        /// <exception cref="ArgumentNullException">Throws exception if source or paging are null.</exception>
        public PagedList(IList<T> source, IPaging paging)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            Paging = paging ?? throw new ArgumentNullException(nameof(paging));
        }

        /// <summary>
        /// Creates new paged list instance.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="page">Current page.</param>
        /// <param name="recordsPerPage">Records per page</param>
        /// <exception cref="ArgumentNullException">Throws exception if source is null.</exception>
        public PagedList(IList<T> source, int page, int recordsPerPage)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            page = page < 1 ? 1 : page;
            recordsPerPage = recordsPerPage < 1 ? 1 : recordsPerPage;

            var result = source.Skip((page - 1) * recordsPerPage).Take(recordsPerPage).ToList();
            Paging = new PagingBase(page, recordsPerPage, result.Count());
            _source = result.ToList();
        }

        /// <inheritdoc />
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _source.Count)
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index out of range.");
                return _source[index];
            }
        }

        /// <inheritdoc />
        public IPaging Paging { get; }

        /// <inheritdoc />
        public int Count()
        {
            return _source.Count;
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return _source.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _source.GetEnumerator();
        }

        /// <inheritdoc />
        public IPagedList<T> Empty()
        {
            return new PagedList<T>(Enumerable.Empty<T>().ToList(), 1, 1);
        }
    }
}
