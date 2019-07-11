using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// Time clock entity.
    /// </summary>
    public class TimeClock
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
