using System.Net.Http.Json;
using SmartShop.Shared;

namespace SmartShop.Web.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        // GET PRODUCTS
        public async Task<List<Product>> GetProducts()
        {
            return await _http.GetFromJsonAsync<List<Product>>("api/products");
        }

        // ADD PRODUCT
        public async Task AddProduct(Product product)
        {
            await _http.PostAsJsonAsync("api/products", product);
        }

        // UPDATE PRODUCT
        public async Task UpdateProduct(Product product)
        {
            await _http.PutAsJsonAsync($"api/products/{product.Id}", product);
        }

        // DELETE PRODUCT
        public async Task DeleteProduct(int id)
        {
            await _http.DeleteAsync($"api/products/{id}");
        }
    }
}