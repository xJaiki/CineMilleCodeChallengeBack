using CineMilleCodeChallenge.Models;
using CineMilleCodeChallenge.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<User> RegisterUser(UserAuth user)
        {
            // Verifica se l'utente esiste già
            var existingUser = await _userRepository.GetUserByUsername(user.Username);
            if (existingUser != null)
            {
                throw new Exception("Username già in uso");
            }

            if(user.Username.StartsWith("a_"))
            {
                return await _userRepository.CreateAdmin(user);
            }

            return await _userRepository.CreateUser(user);
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            // Verifica delle credenziali
            var user = await _userRepository.GetUserByUsernameAndPassword(username, password);
            if (user == null)
            {
                throw new Exception("Username o password non corretti");
            }

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<User> UpdateUserRole(string username, string role)
        {
            return await _userRepository.UpdateUserRole(username, role);
        }

        public async Task<User> DeleteUser(string id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<User> GetUserById(string id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
