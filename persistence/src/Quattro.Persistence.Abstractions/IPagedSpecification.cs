namespace Quattro.Persistence.Abstractions
{
    /// <summary>
    /// Paged specification.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedSpecification<T> : ISpecification<T>
    {
        /// <summary>
        /// Page.
        /// </summary>
        int Page { get; }

        /// <summary>
        /// Number of records per page.
        /// </summary>
        int RecordsPerPage { get; }

        /// <summary>
        /// Indicates whether paging is enabled or not.
        /// </summary>
        bool PagingEnabled { get; }
    }
}
