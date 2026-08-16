using EventSample.Models;

namespace EventSample.Events
{
    public class UserRegisteredEventArgs : EventArgs
    {
        public User? User { get; set; }
    }
}
