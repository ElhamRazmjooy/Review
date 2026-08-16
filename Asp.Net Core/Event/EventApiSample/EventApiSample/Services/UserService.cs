using EventApiSample.Events;
using EventApiSample.Models;

namespace EventApiSample.Services
{
    public class UserService
    {
        public event EventHandler<UserRegisteredEventArgs>? UserRegistered;
        public User Register(User user)
        {
            Console.WriteLine("User Saved.");
            UserRegistered?.Invoke(this, new UserRegisteredEventArgs { User = user});
            return user;
        }
    }
}
