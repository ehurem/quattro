using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Dtos
{
    /// <summary>
    /// Time clock data transfer object.
    /// </summary>
    public class TimeClockDto
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
        /// Start date.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Time clock description. May be set as CLOCK-IN or CLOCK-OUT.
        /// </summary>
        public string Description { get; set; }
    }
}
