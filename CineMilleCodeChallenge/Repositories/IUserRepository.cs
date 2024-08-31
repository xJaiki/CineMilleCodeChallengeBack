using CineMilleCodeChallenge.Models;

namespace CineMilleCodeChallenge.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string id);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByUsernameAndPassword(string username, string password);
        Task<User> CreateUser(UserAuth user);
        Task<User> CreateAdmin(UserAuth user);
        Task<User> UpdateUser(User user);
        Task<User> UpdateUserRole(string username, string role);
        Task<User> DeleteUser(string id);
        Task<List<User>> GetAllUsers();
    }
}
