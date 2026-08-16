using BackgroundServiceSample.Models;

namespace BackgroundServiceSample.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task DeleteInactiveUsersAsync(CancellationToken cancellationToken);
    }
}
