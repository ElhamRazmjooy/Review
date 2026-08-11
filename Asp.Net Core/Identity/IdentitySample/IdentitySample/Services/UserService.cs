using IdentitySample.Models;

namespace IdentitySample.Services
{
    public class UserService
    {
        private readonly List<User> users =
        [
            new User
            {
                Id = 1,
                Username = "ali",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                Role = "Admin",
                Permissions =
                [
                    "users.delete",
                    "users.create"
                ]
            },
            new User
            {
                Id = 2,
                Username = "sara",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("111111"),
                Role = "User",
                Permissions =
                [
                    "users.create"
                ]
            }
        ];
        public User? ValidateUser(string username, string password)
        {
            var user = users.FirstOrDefault(x => x.Username == username);

            if (user == null) return null;
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) return null;

            return user;
        }
            
    }
}
