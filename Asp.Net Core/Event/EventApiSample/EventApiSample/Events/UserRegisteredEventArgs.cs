using EventApiSample.Models;

namespace EventApiSample.Events
{
    public class UserRegisteredEventArgs : EventArgs
    {
        public User? User { get; set; } 
    }
}
