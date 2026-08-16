using EventSample.Events;
using EventSample.Models;
using EventSample.Services;

var userService = new UserService();
userService.UserRegistered += SendWelcomeEmail;
userService.UserRegistered += WriteLog;
userService.UserRegistered += SendNotification;

var user = new User 
{
    Id = 1, 
    Name =  "Ali", 
    Email = "Ali@Test.com" 
};

userService.UserRegistered -= WriteLog;
userService.Register(user);
Console.ReadLine();

//Subscriber
static void SendWelcomeEmail(object? sender, UserRegisteredEventArgs e) => 
    Console.WriteLine($"Welcome Email Sent To {e.User.Email}.");
static void WriteLog(object? sender, UserRegisteredEventArgs e) => 
    Console.WriteLine($"Log: User {e.User.Name} Registered.");
static void SendNotification(object? sender, UserRegisteredEventArgs e) => 
    Console.WriteLine($"Notification Sent for {e.User.Name}.");

