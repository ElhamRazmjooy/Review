namespace BackgroundServiceSample.Services
{
    public class UserCleanupService(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Background Service STARTED!");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = scopeFactory.CreateScope();
                    var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                    await userService.DeleteInactiveUsersAsync(stoppingToken);
                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Background Service Error: {ex.Message}");
                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                }
            }
            Console.WriteLine("Background Service STOPPED!");
        }
    }
}
