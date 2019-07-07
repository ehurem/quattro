using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Quattro.Persistence.Abstractions
{
    /// <summary>
    /// Specification.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Predicate.
        /// </summary>
        Expression<Func<T, bool>> Predicate { get; }

        /// <summary>
        /// Properties to include.
        /// </summary>
        IEnumerable<Expression<Func<T, object>>> Includes { get; }

        /// <summary>
        /// Names of properties to include.
        /// </summary>
        IEnumerable<string> IncludeStrings { get; }

        /// <summary>
        /// OrderBy clause.
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }

        /// <summary>
        /// OrderByDescending clause.
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }
    }
}
