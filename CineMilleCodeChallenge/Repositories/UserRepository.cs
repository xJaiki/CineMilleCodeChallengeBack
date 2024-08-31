using CineMilleCodeChallenge.Data;
using CineMilleCodeChallenge.Helpers;
using CineMilleCodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CineMilleCodeChallenge.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User> CreateUser(UserAuth user)
        {
            User newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = user.Username,
                PasswordHash = PasswordHasher.HashPassword(user.Password),
                Role = "user"
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(); 
            return newUser;
        }

        public async Task<User> CreateAdmin(UserAuth user)
        {
            User newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = user.Username,
                PasswordHash = PasswordHasher.HashPassword(user.Password),
                Role = "admin"
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                var existingUser = await _context.Users.FindAsync(user.Id);
                if (existingUser == null)
                {
                    throw new Exception($"Utente con id {user.Id} non trovato");
                }

                existingUser.Username = user.Username;
                if (existingUser.PasswordHash != user.PasswordHash)
                {
                    existingUser.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
                }
                existingUser.Role = user.Role;

                await _context.SaveChangesAsync();
                return existingUser;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nell'aggiornamento dell'utente con id {user.Id}: {e.Message}");
            }
        }

        public async Task<User> UpdateUserRole(string username, string role){
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username) ?? throw new Exception($"Utente con username {username} non trovato");
                user.Role = role;
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nell'aggiornamento del ruolo dell'utente con username {username}: {e.Message}");
            }
        }

        public async Task<User> DeleteUser(string id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id) ?? throw new Exception($"Utente con id {id} non trovato");
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nella cancellazione dell'utente con id {id}: {e.Message}");
            }
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (user != null && PasswordHasher.VerifyPassword(password, user.PasswordHash))
                {
                    return user;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nel recupero dell'utente con username {username}: {e.Message}");
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
