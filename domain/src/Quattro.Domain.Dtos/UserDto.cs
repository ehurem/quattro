using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Dtos
{
    /// <summary>
    /// User data transfer object.
    /// </summary>
    public class UserDto
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
        /// User profile id.
        /// </summary>
        public int ProfileId { get; set; }
        /// <summary>
        /// User status id.
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// User employee profile.
        /// </summary>
        public EmployeeDto Profile { get; set; }
        /// <summary>
        /// User status.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// User roles.
        /// </summary>
        public ICollection<RoleDto> Roles { get; set; }
        /// <summary>
        /// User time clocks.
        /// </summary>
        public ICollection<TimeClockDto> TimeClocks { get; set; }
    }
}
