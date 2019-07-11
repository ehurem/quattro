using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// Scope entity.
    /// </summary>
    public class Scope
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Scope name in format {resource}:{action}.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Scope description.
        /// </summary>
        public string Description { get; set; }
    }
}
