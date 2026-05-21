using Microsoft.EntityFrameworkCore;
using SmartShop.InventoryWorker.Data;

namespace SmartShop.InventoryWorker
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<Worker> _logger;

        public Worker(
            IServiceScopeFactory scopeFactory,
            ILogger<Worker> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope =
                    _scopeFactory.CreateScope();

                var context =
                    scope.ServiceProvider
                         .GetRequiredService<InventoryDbContext>();

                // Get all products
                var products =
                    await context.Products.ToListAsync();

                foreach (var product in products)
                {
                    // Decrease quantity
                    if (product.Quantity > 0)
                    {
                        product.Quantity--;

                        _logger.LogInformation(
                            $"{product.Name} quantity decreased to {product.Quantity}");

                        // Low stock warning
                        if (product.Quantity < 5)
                        {
                            _logger.LogWarning(
                                $"WARNING: {product.Name} stock is low!");
                        }
                    }
                }

                // Save changes
                await context.SaveChangesAsync();

                // Wait 5 seconds
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}