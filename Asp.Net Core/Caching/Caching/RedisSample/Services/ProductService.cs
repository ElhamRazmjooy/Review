using Microsoft.Extensions.Caching.Distributed;
using RedisCacheSample.Models;
using System.Text.Json;

namespace RedisCacheSample.Services
{
    public class ProductService(IDistributedCache cache)
    {
        const string cacheKey = "products";
        public async Task<List<Product>> GetProductsAsync()
        {
            var cachedData = await cache.GetStringAsync(cacheKey);

            if (cachedData is not null)
            {
                Console.WriteLine("Redis Cache HIT");
                return JsonSerializer.Deserialize<List<Product>>(cachedData)!;
            }
            Console.WriteLine("Redis Cache MISS");
            var products = await GetProductsFromDatabaseAsync();
            var json = JsonSerializer.Serialize(products);
            var option = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
            await cache.SetStringAsync(cacheKey, json, option);
            return products;
        }
        public async Task InvalidateCacheAsync()
        {
            await cache.RemoveAsync(cacheKey);
            Console.WriteLine("REDIS CACHE INVALIDATED");
        }
        private async Task<List<Product>> GetProductsFromDatabaseAsync()
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
