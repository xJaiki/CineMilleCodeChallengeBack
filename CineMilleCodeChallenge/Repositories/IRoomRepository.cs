using CineMilleCodeChallenge.Models;

namespace CineMilleCodeChallenge.Repositories
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomById(int id);
        Task<Room> CreateRoom(Room room);
        Task<Room> UpdateRoom(Room room);
        Task<Room> DeleteRoom(int id);
        Task<List<Room>> GetAllRooms();
        Task<List<Room>> GetAvailableRooms(DateTime date);

    }
}
