using Microsoft.EntityFrameworkCore;
using SmartShop.Shared;

namespace SmartShop.AuthApi.Data;

public class AuthDbContext : DbContext
{
    public AuthDbContext(
        DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}
