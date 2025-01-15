using Microsoft.EntityFrameworkCore;
using ShoppingCartService.Models;

namespace ShoppingCartService.DatabaseAccess
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
