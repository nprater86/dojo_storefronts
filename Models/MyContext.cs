using Microsoft.EntityFrameworkCore;
namespace dojo_storefronts.Models;
// the MyContext class representing a session with our MySQL 
// database allowing us to query for or save data
public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    // the table name will come from the DbSet variable name
    public DbSet<User> Users { get; set; }
    public DbSet<SubmittedOrder> SubmittedOrders { get; set; }
    public DbSet<Storefront> Storefronts { get; set; }
    public DbSet<ShippingAddress> ShippingAddresses { get; set; }
    public DbSet<ProductsInSubmittedOrder> ProductsInSubmittedOrders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<ProductsInCart> ProductsInCarts {get; set;}
}