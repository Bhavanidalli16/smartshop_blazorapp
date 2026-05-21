using Microsoft.EntityFrameworkCore;
using SmartShop.Shared;

namespace SmartShop.InventoryWorker.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(
            DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}