using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Data;
using ShoppingCart.Model;

namespace ShoppingCart.Pages.ProductDetail
{
    public class CreateModel : PageModel
    {
        private readonly ShoppingCartDbContext _context;
        public CreateModel(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public Product Product { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Product product)
        {

            if(!ModelState.IsValid)
            { 
                return Page();
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            TempData["success"] = "Product created sucessfully";
            return RedirectToPage("Index");
        }
    }
}
