using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string  Description { get; set; }
        /// <summary>
        /// Number of items in the cart
        /// </summary>
        [NotMapped]
        public int Count { get; set; }
    }
}
