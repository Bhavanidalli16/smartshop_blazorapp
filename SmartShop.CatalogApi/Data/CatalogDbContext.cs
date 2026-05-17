using Microsoft.EntityFrameworkCore;
using SmartShop.Shared;

namespace SmartShop.CatalogApi.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(
        DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}