using CineMilleCodeChallenge.Data;
using CineMilleCodeChallenge.Helpers;
using CineMilleCodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CineMilleCodeChallenge.Repositories
{
    public class RoomRepository(ApplicationDbContext context) : IRoomRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Room> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> DeleteRoom(int id)
        {
            try
            {
                var room = await _context.Rooms.FindAsync(id) ?? throw new Exception($"Sala con id {id} non trovato");
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                return room;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nella cancellazione della sala con id {id}: {e.Message}");
            }
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            try
            {
                Room existingRoom = await _context.Rooms.FindAsync(room.Id);
                if (existingRoom == null)
                {
                    throw new Exception($"Sala con id {room.Id} non trovato");
                }

                existingRoom.Name = room.Name;
                existingRoom.Capacity = room.Capacity;
                existingRoom.IsIMAX = room.IsIMAX;

                await _context.SaveChangesAsync();
                return existingRoom;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nell'aggiornamento della sala con id {room.Id}: {e.Message}");
            }
        }

        public async Task<List<Room>> GetAvailableRooms(DateTime date)
        {
            DateTime startOfWeek = DateTimeHelper.GetStartOfWeek(date);
            DateTime endOfWeek = DateTimeHelper.GetEndOfWeek(date);

            List<Room> rooms = await _context.Rooms.ToListAsync();
            List<Schedule> schedules = await _context.Schedules.Where(s => s.StartDate >= startOfWeek && s.StartDate <= endOfWeek || s.EndDate >= startOfWeek && s.EndDate <= endOfWeek).ToListAsync();

            return rooms.Where(r => !schedules.Any(s => s.RoomId == r.Id)).ToList();
        }
    }
}
