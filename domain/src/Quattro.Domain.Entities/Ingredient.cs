using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// Ingredient entity.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ingredient name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ingredient measurement unit.
        /// </summary>
        public string MeasurementUnit { get; set; }
        /// <summary>
        /// Ingredient quantity.
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Ingredient date created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Ingredient date modified.
        /// </summary>
        public DateTime DateModified { get; set; }
        /// <summary>
        /// Ingredient created by indicator.
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ingredient modified by indicator.
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Ingredient active indicator.
        /// </summary>
        public bool Active { get; set; }
    }
}
