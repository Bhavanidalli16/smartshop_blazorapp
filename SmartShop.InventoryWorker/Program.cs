using Microsoft.EntityFrameworkCore;
using SmartShop.InventoryWorker;
using SmartShop.InventoryWorker.Data;

var builder = Host.CreateApplicationBuilder(args);

// Register DbContext
builder.Services.AddDbContext<InventoryDbContext>(
    options =>
    options.UseSqlServer(
        "Server=(localdb)\\MSSQLLocalDB;Database=CatalogDb;Trusted_Connection=True;"));

// Register Worker Service
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();