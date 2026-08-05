using _02_DapperRepository.Models;

namespace _02_DapperRepository.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);

    }
}
