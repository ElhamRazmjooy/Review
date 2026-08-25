namespace ConcurrencySample.Services
{
    public class ProductService
    {
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        public async Task<string[]> GetProductsAsync()
        {
            var task1 = GetProductAsync(1);
            var task2 = GetProductAsync(2); 
            var task3 = GetProductAsync(3);
            await Task.WhenAll(task1, task2, task3);
            return
            [
                await task1,
                await task2,
                await task3
            ];
        }
        private async Task<string> GetProductAsync(int id)
        {
            await Task.Delay(1000);
            return $"Product {id}";
        }
        public async Task<string> CriticalOperationAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                Console.WriteLine($"Started: {DateTime.Now:HH:mm:ss.fff}");
                await Task.Delay(2000);
                Console.WriteLine($"Finished: {DateTime.Now:HH:mm:ss.fff}");
                return "Operation Completed!";
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
