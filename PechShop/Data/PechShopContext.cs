using Microsoft.EntityFrameworkCore;
using PechShop.Models;

namespace PechShop.Data
{
    public class PechShopContext : DbContext
    {
        public PechShopContext (DbContextOptions<PechShopContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
