using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Data;
using ShoppingCart.Model;

namespace ShoppingCart.Pages.ProductDetail
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingCartDbContext _context;
        // we need an implementation of the class
        public IEnumerable<Product> Products { get; set; }
        public IndexModel(ShoppingCartDbContext context)
        {
            // will have the implmentation of the dbcontext that connects to the database
            _context = context;    
        }
        public void OnGet()
        {
            Products = _context.Products;
        }
    }
}
