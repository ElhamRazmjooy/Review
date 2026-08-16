using EventSample.Events;
using EventSample.Models;

namespace EventSample.Services
{
    public class UserService
    {
        public event EventHandler<UserRegisteredEventArgs>? UserRegistered;
        public void Register(User user)
        {
            Console.WriteLine($"User {user.Name} registered.");
            UserRegistered?.Invoke(this, new UserRegisteredEventArgs { User = user});
        }
    }
}
