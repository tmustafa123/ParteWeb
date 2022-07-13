using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Data;
using ShoppingCart.Model;

namespace ShoppingCart.Pages.ProductDetail
{
    public class EditModel : PageModel
    {
        private readonly ShoppingCartDbContext _context;
        public EditModel(ShoppingCartDbContext context)
        {
            _context = context;

        }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.SingleOrDefault(item => item.ProductId == id);
        }

        public async Task<IActionResult> OnPost()
        {

            if(!ModelState.IsValid)
            { 
                return Page();
            }
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();
            TempData["success"] = "Product edited sucessfully";
            return RedirectToPage("Index");
        }
    }
}
