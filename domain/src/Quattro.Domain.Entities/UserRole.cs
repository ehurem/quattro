using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// User role bridge entity.
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Identifier.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User.
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Role Identifier.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Role.
        /// </summary>
        public Role Role { get; set; }
    }
}
