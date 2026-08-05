using Dapper;
using DapperRepository.Models;
using System.Data;

namespace DapperRepository.Repositories
{
    public class UserRepository(IDbConnection db) : IUserRepository
    {
        private readonly IDbConnection _db = db;
        public async Task<IEnumerable<User>> GetAllAsync() => await _db.QueryAsync<User>(@"SELECT * FROM Users");
        public async Task<User?> GetByIdAsync(int id) => await _db.QueryFirstOrDefaultAsync<User>(@"SELECT * FROM Users WHERE Id = @Id", new { Id = id});
        public async Task AddAsync(User user) => await _db.ExecuteAsync(@"INSERT INTO Users(Name, Age) VALUES(@Name, @Age)", user);
        public async Task UpdateAsync(User user) => await _db.ExecuteAsync(@"UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id", user);
        public async Task DeleteAsync(int id) => await _db.ExecuteAsync(@"DELETE FROM Users WHERE Id = @Id", new { Id = id });
    }
}
