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
        // 2 ways 
        // use the bind property
        // the post recieves the object
        // It extracts posted form values that match the names of the parameters
        public async Task<IActionResult> OnPost(Product product)
        {

            if(!ModelState.IsValid)
            {
              //  ModelState.AddModelError(string.Empty, "Invalid Model"); 
                return Page();
            }

            // the object that needs to be added to the table 
            await _context.Products.AddAsync(product);
            // here we tell it to do that adding now
            // takes all the changes and makes it in the db
            // if we redirect before 
            await _context.SaveChangesAsync();
            TempData["success"] = "Product created sucessfully";
            return RedirectToPage("Index");
        }
    }
}
