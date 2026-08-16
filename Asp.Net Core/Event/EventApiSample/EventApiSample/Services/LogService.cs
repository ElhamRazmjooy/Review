using EventApiSample.Events;

namespace EventApiSample.Services
{
    public class LogService
    {
        public void Subscribe(UserService userService) => userService.UserRegistered += WriteLog;
        private void WriteLog(object? sender, UserRegisteredEventArgs e) => 
            Console.WriteLine($"Log Created for: {e.User.Name}");
    }
}
