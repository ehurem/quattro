using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// RoleScope bridge entity.
    /// </summary>
    public class RoleScope
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Role Identifier.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Role.
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// Scope Identifier.
        /// </summary>
        public int ScopeId { get; set; }
        /// <summary>
        /// Scope.
        /// </summary>
        public Scope Scope { get; set; }
    }
}
