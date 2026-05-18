using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.CatalogApi.Data;
using SmartShop.Shared;

namespace SmartShop.CatalogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly CatalogDbContext _context;

    public ProductsController(CatalogDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products =
            await _context.Products.ToListAsync();

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();

        return Ok(product);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product updatedProduct)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Quantity = updatedProduct.Quantity;

        await _context.SaveChangesAsync();

        return Ok(product);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return Ok("Product deleted successfully");
    }
}