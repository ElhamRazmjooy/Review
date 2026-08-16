using BackgroundServiceSample.Data;
using BackgroundServiceSample.Models;
using Microsoft.EntityFrameworkCore;

namespace BackgroundServiceSample.Services
{
    public class UserService(AppDbContext db) : IUserService
    {
        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken) => await db.Users
            .AsNoTracking().ToListAsync(cancellationToken);
        
        public async Task DeleteInactiveUsersAsync(CancellationToken cancellationToken)
        {
            var inactiveUsers = await db.Users.Where(x => !x.IsActive).ToListAsync(cancellationToken);
            if (inactiveUsers.Count == 0)
            {
                Console.WriteLine("No inactive users found.");
                return;
            }
            db.Users.RemoveRange(inactiveUsers);
            await db.SaveChangesAsync(cancellationToken);
            foreach (var user in inactiveUsers)
            {
                Console.WriteLine($"Deleted inactive user: {user.Name}");
            }
        }
    }
}
