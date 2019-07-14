using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    /// <summary>
    /// Item entity.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Item name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Item bar code.
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Item description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Item measure unit.
        /// </summary>
        public string MeasurementUnit { get; set; }
        /// <summary>
        /// Item price.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Item image.
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// Item quantity.
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Item created date.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Item modified date.
        /// </summary>
        public DateTime DateModified { get; set; }
        /// <summary>
        /// Item created by modifier.
        /// </summary>
        public DateTime CreatedBy { get; set; }
        /// <summary>
        /// Item category.
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// Item ingredients.
        /// </summary>
        public ICollection<IngredientsForItems> IngredientsForItems { get; set; }
    }
}
