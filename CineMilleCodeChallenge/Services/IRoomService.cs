using CineMilleCodeChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Services
{
    public interface IRoomService
    {
        Task<Room> CreateRoom(Room movie);
        Task<Room> UpdateRoom(Room movie);
        Task<Room> DeleteRoom(int id);
        Task<Room> GetRoomById(int id);
        Task<List<Room>> GetAllRooms();
        Task<List<Room>> GetAvailableRooms(string date);
    }
}
