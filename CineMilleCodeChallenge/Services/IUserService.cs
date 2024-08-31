using CineMilleCodeChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Services
{
    public interface IUserService
    {
        Task<User> RegisterUser(UserAuth user);
        Task<User> AuthenticateUser(string username, string password);
        Task<User> UpdateUser(User user);
        Task<User> UpdateUserRole(string username, string role);
        Task<User> DeleteUser(string id);
        Task<User> GetUserById(string id);
        Task<User> GetUserByUsername(string username);
        Task<List<User>> GetAllUsers();
    }
}
