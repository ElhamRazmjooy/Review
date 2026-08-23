using MemoryCacheSample.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheSample.Services
{
    public class ProductService(IMemoryCache cache)
    {
        const string cacheKey = "products";
        public async Task<List<Product>> GetProductsAsync()
        {
            if (cache.TryGetValue(cacheKey, out List<Product>? products))
            {
                Console.WriteLine("Cache HIT");
                return products!;
            }
            Console.WriteLine("Cache MISS");

            products = await GetProductsFromDatabaseAsync();

            var options = new MemoryCacheEntryOptions
            { 
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(2),
            };

            cache.Set(cacheKey, products, options);
            return products!;
        }
        public void InvalidateProductsCache()
        {
            cache.Remove("products");
            Console.WriteLine("CACHE INVALIDATED");
        }
        private async Task<List<Product>?> GetProductsFromDatabaseAsync()
        {
            await Task.Delay(1000);
            return
            [
                new()
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 50000
                },
                new()
                {
                    Id = 2,
                    Name = "Mouse",
                    Price = 1500
                }
            ];
        }
    }
}
