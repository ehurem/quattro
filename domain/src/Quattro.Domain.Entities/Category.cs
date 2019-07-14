using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// Category entity.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Category description.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Category active indicator.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Category subcategory.
        /// </summary>
        public Category Subcategory { get; set; }
    }
}
