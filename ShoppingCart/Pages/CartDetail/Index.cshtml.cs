using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Data;
using ShoppingCart.Model;

namespace ShoppingCart.Pages.CartDetail
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingCartDbContext _context;
        public IEnumerable<Cart> Carts { get; set; }
        public IndexModel(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            // group the cart items for a cart
            // compute the number of items in each cart
            var results = _context.CartItems.GroupBy(
                    p => p.CartId,
                    (key, g) => new Cart { 
                        Id = key,
                        Name = _context.Carts.SingleOrDefault(i=> i.Id == key).Name,
                        Description = _context.Carts.SingleOrDefault(i => i.Id == key).Description,
                        Count = g.Count(),
                    });

            Carts = results;
        }
    }
}
