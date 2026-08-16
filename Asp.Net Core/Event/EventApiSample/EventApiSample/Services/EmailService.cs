using EventApiSample.Events;

namespace EventApiSample.Services
{
    public class EmailService
    {
        public void Subscribe(UserService userService) => userService.UserRegistered += SendEmail;
        private void SendEmail(object? sender, UserRegisteredEventArgs e) => 
            Console.WriteLine($"Email Sent to: {e.User.Email}");
    }
}
