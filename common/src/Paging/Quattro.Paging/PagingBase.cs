using System;
using System.Runtime.Serialization;
using Quattro.Paging.Abstractions;

namespace Quattro.Paging
{
    [Serializable]
    public class PagingBase : IPaging
    {
        /// <inheritdoc />
        public int CurrentPage { get; private set; }

        /// <inheritdoc />
        public int RecordsPerPage { get; private set; }

        /// <inheritdoc />
        public int TotalPages { get; private set; }

        /// <inheritdoc />
        public int TotalRecords { get; private set; }

        /// <inheritdoc />
        public int FirstPage => 1;

        /// <inheritdoc />
        public int LastPage => TotalPages < 1 ? 1 : TotalPages;

        /// <inheritdoc />
        public int PageIndex { get; private set; }

        /// <inheritdoc />
        public bool HasNextPage => CurrentPage < TotalPages;

        /// <inheritdoc />
        public bool HasPreviousPage => CurrentPage > 1;

        private PagingBase() { }

        /// <summary>
        /// Creates paging model.
        /// </summary>
        /// <param name="currentPage">Current page.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <param name="totalRecords">Total records.</param>
        public PagingBase(int currentPage, int recordsPerPage, int totalRecords)
        {
            InitializePaging(currentPage, recordsPerPage, totalRecords);
        }

        protected PagingBase(SerializationInfo info, StreamingContext context)
        {
            CurrentPage = info.GetInt32(nameof(CurrentPage));
            RecordsPerPage = info.GetInt32(nameof(RecordsPerPage));
            TotalPages = info.GetInt32(nameof(TotalPages));
            TotalRecords = info.GetInt32(nameof(TotalRecords));
            PageIndex = info.GetInt32(nameof(PageIndex));
        }

        /// <inheritdoc />
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(CurrentPage), CurrentPage);
            info.AddValue(nameof(RecordsPerPage), RecordsPerPage);
            info.AddValue(nameof(TotalPages), TotalPages);
            info.AddValue(nameof(TotalRecords), TotalRecords);
            info.AddValue(nameof(PageIndex), PageIndex);
        }

        private void InitializePaging(int currentPage, int recordsPerPage, int totalRecords)
        {
            TotalRecords = totalRecords < 1 ? 0 : totalRecords;
            RecordsPerPage = recordsPerPage < 1 ? 1 : recordsPerPage;

            var totalPages = TotalRecords / RecordsPerPage;
            totalPages = (TotalRecords % RecordsPerPage) > 0 ? totalPages + 1 : totalPages;

            var page = currentPage < 1 ? 1 : currentPage;

            CurrentPage = totalPages != 0 && page > totalPages ? totalPages : page;
            TotalPages = totalPages;
            PageIndex = (int)(CurrentPage - 1);
        }
    }
}
