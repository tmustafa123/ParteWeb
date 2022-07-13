using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// database
// which class is implmenting the db context
// here we are just adding items to the container, that we will use later via DI
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ShoppingCartDbContext>(options=>options.UseSqlServer(connection));
// for mvc
// builder.Services.AddControllersWithViews();
// DI
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// middlewares
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
// configure the routing of the razor pages
app.MapRazorPages();

app.Run();
