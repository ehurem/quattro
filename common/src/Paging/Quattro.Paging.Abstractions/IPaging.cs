using System.Runtime.Serialization;

namespace Quattro.Paging.Abstractions
{
    /// <summary>
    /// Represents paging interface.
    /// </summary>
    public interface IPaging : ISerializable
    {
        /// <summary>
        /// Current page.
        /// </summary>
        int CurrentPage { get; }

        /// <summary>
        /// Number of records per page.
        /// </summary>
        int RecordsPerPage { get; }

        /// <summary>
        /// Total number of pages.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Total number of records.
        /// </summary>
        int TotalRecords { get; }

        /// <summary>
        /// First page.
        /// </summary>
        int FirstPage { get; }

        /// <summary>
        /// Last page.
        /// </summary>
        int LastPage { get; }

        /// <summary>
        /// Page index.
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Has next page.
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// Has previous page.
        /// </summary>
        bool HasPreviousPage { get; }
    }
}
