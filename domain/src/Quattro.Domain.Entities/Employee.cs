using System;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// Employee entity.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User Identifier.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Phone number.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Employee image url.
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Birthday.
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Employee hire/start date.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Employee fire/end date.
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Manager Identifier.
        /// </summary>
        public int? ManagerId { get; set; }
        /// <summary>
        /// Manager.
        /// </summary>
        public Employee Manager { get; set; }
    }
}
