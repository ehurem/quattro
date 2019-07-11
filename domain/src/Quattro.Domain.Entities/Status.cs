using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// Status entity.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Status name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Status description.
        /// </summary>
        public string Description { get; set; }
    }
}
