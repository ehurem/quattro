using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// Role entity.
    /// </summary>
    public class Role
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
        /// Role scopes.
        /// </summary>
        public ICollection<RoleScope> RoleScopes { get; set; }
    }
}
