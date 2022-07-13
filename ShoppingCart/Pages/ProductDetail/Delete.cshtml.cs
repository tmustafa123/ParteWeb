using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Data;
using ShoppingCart.Model;

namespace ShoppingCart.Pages.ProductDetail
{
    public class DeleteModel : PageModel
    {
        private readonly ShoppingCartDbContext _context;
        public DeleteModel(ShoppingCartDbContext context)
        {
            _context = context;

        }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            // you passed the id in the asp-route-id
            Product = _context.Products.SingleOrDefault(item => item.ProductId == id);
        }

        public async Task<IActionResult> OnPost()
        {

            var itemToDelete = _context.Products.Find(Product.ProductId);

            if (itemToDelete == null)
                return NotFound();

            _context.Products.Remove(itemToDelete);
            await _context.SaveChangesAsync();
            TempData["success"] = "Product deleted sucessfully";
            return RedirectToPage("Index");
        }
    }
}
