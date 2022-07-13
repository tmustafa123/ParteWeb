using Microsoft.EntityFrameworkCore;
using ShoppingCart.Model;

namespace ShoppingCart.Data
{
    public class ShoppingCartDbContext: DbContext
    {
        // pass the options to the parent/base class
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {

        }
        // connection string as options
        // dbset for all the tables
        // the name you want in your db 
        // here now we can get the options
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
