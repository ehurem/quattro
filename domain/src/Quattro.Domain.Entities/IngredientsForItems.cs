using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Domain.Entities
{
    public class IngredientsForItems
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Item Identifier.
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Item.
        /// </summary>
        public Item Item { get; set; }
        /// <summary>
        /// Ingredient Identifier.
        /// </summary>
        public int IngredientId { get; set; }
        /// <summary>
        /// Ingredient.
        /// </summary>
        public Ingredient Ingredient { get; set; }
    }
}
