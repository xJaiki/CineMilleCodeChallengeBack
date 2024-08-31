using CineMilleCodeChallenge.Models;
using CineMilleCodeChallenge.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Services
{
    public class RoomService(IRoomRepository roomRepository) : IRoomService
    {
        private readonly IRoomRepository _roomRepository = roomRepository;

        public Task<Room> CreateRoom(Room room)
        {
            return _roomRepository.CreateRoom(room);
        }

        public Task<Room> DeleteRoom(int id)
        {
            return _roomRepository.DeleteRoom(id);
        }

        public Task<List<Room>> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public Task<Room> GetRoomById(int id)
        {
            return _roomRepository.GetRoomById(id);
        }

        public Task<Room> UpdateRoom(Room room)
        {
            return _roomRepository.UpdateRoom(room);
        }

        public Task<List<Room>> GetAvailableRooms(string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            return _roomRepository.GetAvailableRooms(dateTime);
        }
    }
}
