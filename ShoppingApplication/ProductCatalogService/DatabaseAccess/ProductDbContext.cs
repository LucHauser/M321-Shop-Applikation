using Microsoft.EntityFrameworkCore;
using ProductCatalogService.Models;

namespace ProductCatalogService.DatabaseAccess
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
