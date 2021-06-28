using BaltaShop.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace BaltaShop.Products.Data
{
    public class ShopDataContext : DbContext
    {
        public ShopDataContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
