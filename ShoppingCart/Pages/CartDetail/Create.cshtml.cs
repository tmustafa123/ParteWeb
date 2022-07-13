using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Data;
using ShoppingCart.Model;

namespace ShoppingCart.Pages.CartDetail
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ShoppingCartDbContext _context;
        public  List<int> AreAdded  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// display user the list of items
        /// </summary>
        public IEnumerable<Product> Products { get; set; }
       
        public CreateModel(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Products = _context.Products;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if(AreAdded.Count > 0)
            {
                // create the cart
                var newCart = new Cart
                {
                    Name = Name,
                    Description = Description,
                };
                await _context.Carts.AddAsync(newCart);
                await _context.SaveChangesAsync();

                var cart = _context.Carts.SingleOrDefault(cart=> cart.Id == newCart.Id);

                foreach (var productId in AreAdded)
                {
                    // create the cart items
                    var product = _context.Products.SingleOrDefault(item => item.ProductId == productId);
                    if (product != null && cart!= null)
                    {
                        var cartItem = new CartItem
                        {
                            CartId = cart.Id,
                            ProductId = product.ProductId,
                            Quantity = 1
                        };
                        await _context.CartItems.AddAsync(cartItem);
                        await _context.SaveChangesAsync();
                    }
                }

            }
            TempData["success"] = "Cart saved sucessfully";
            return RedirectToPage("Index");
        }
    }
}
