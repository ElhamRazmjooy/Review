using System.Diagnostics;

namespace ConcurrencySample02.Services
{
    public class ConcurrencyService
    {
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private int _counter;
        public async Task<object> RunParallelTasksAsync(CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            var tasks = Enumerable.Range(1, 5).Select(id => ProcessItemAsync(id, cancellationToken)).ToArray();
            var result = await Task.WhenAll(tasks);
            stopwatch.Stop();
            return new
            {
                Result = result,
                stopwatch.ElapsedMilliseconds
            };
        }
        private async Task<string> ProcessItemAsync(int id, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            return $"Item {id} Proccesed by {Environment.CurrentManagedThreadId}";
        }
        public async Task<string> CriticalSectionAsync(CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync();
            try
            {
                Console.WriteLine($"Started: {DateTime.Now:HH:mm:ss.fff}");
                await Task.Delay(2000, cancellationToken);
                Console.WriteLine($"Finished: {DateTime.Now:HH:mm:ss.fff}");
                return $"Critical Operation Completed.";
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task<int> IncrementCounterAsync(CancellationToken cancellationToken)
        {
            var tasks = Enumerable.Range(1, 5).Select(id => IncrementAsync(cancellationToken));
            await Task.WhenAll(tasks);
            return _counter;
        }
        private async Task IncrementAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();
            Interlocked.Increment(ref _counter);
        }
        public int GetCounter() => _counter;
    }
}
