using System.Collections.Generic;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// User entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User name.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User profile id.
        /// </summary>
        public int ProfileId { get; set; }
        /// <summary>
        /// User status id.
        /// </summary>
        public int StatusId  { get; set; }
        /// <summary>
        /// User employee profile.
        /// </summary>
        public Employee Profile { get; set; }
        /// <summary>
        /// User status.
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// User roles.
        /// </summary>
        public ICollection<UserRole> UserRoles { get; set; }
        /// <summary>
        /// User time clocks.
        /// </summary>
        public ICollection<TimeClock> TimeClocks { get; set; }
    }
}
