using _02_DapperRepository.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace _02_DapperRepository.Repositories
{
    public class UserRepository(string connectionString) : IUserRepository
    {
        private readonly string _connectionString = connectionString;
        private SqlConnection CreateConnection() => new(_connectionString);
        public IEnumerable<User> GetAll()
        {
            using var connection = CreateConnection();
            return connection.Query<User>(@"SELECT * FROM Users");
        }
        public User? GetById(int id)
        {
            using var connection = CreateConnection();
            return connection.QueryFirstOrDefault<User>(@"SELECT * FROM Users WHERE Id = @Id", new { Id = id });
        }
        public void Add(User user)
        {
            using var connection = CreateConnection();
            connection.Execute(@"INSERT INTO Users (Name, Age) VALUES (@Name, @Age)", user);
        }
        public void Update(User user)
        {
            using var connection = CreateConnection();
            connection.Execute(@"UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id", user);
        }
        public void Delete(int id)
        {
            using var connection = CreateConnection();
            connection.Execute(@"DELETE FROM Users WHERE Id = @Id", new { Id = id });
        }
    }

}
