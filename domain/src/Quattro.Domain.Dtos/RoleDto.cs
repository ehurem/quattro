using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Dtos
{
    /// <summary>
    /// Role data transfer object.
    /// </summary>
    public class RoleDto
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Role name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Role description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Role scopes separated with white-space in format {resource}:{action}
        /// </summary>
        public ICollection<string> Scopes { get; set; }
    }
}
