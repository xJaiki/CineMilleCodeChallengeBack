using CineMilleCodeChallenge.Data;
using CineMilleCodeChallenge.Helpers;
using CineMilleCodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CineMilleCodeChallenge.Repositories
{
    public class ScheduleRepository(ApplicationDbContext context) : IScheduleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> DeleteSchedule(int id)
        {
            try
            {
                var schedule = await _context.Schedules.FindAsync(id) ?? throw new Exception($"Programmazione con id {id} non trovato");
                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();
                return schedule;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nella cancellazione della programmazione con id {id}: {e.Message}");
            }
        }

        public async Task<List<Schedule>> GetAllSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedule> GetScheduleById(int id)
        {
            return await _context.Schedules.FindAsync(id);
        }

        public async Task<List<Schedule>> GetScheduleByDateWeek(DateTime date)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            DateTime firstDayOfWeek = DateTimeHelper.GetStartOfWeek(date);
            var lastDayOfWeek = firstDayOfWeek.AddDays(6);

            return await _context.Schedules
                .Where(s => s.StartDate >= firstDayOfWeek && s.StartDate <= lastDayOfWeek)
                .ToListAsync();
        }

        

        public async Task<Schedule> UpdateSchedule(Schedule schedule)
        {
            try
            {
                Schedule existingSchedule = await _context.Schedules.FindAsync(schedule.Id);
                if (existingSchedule == null)
                {
                    throw new Exception($"Programmazione con id {schedule.Id} non trovato");
                }

                existingSchedule.MovieId = schedule.MovieId;
                existingSchedule.RoomId = schedule.RoomId;
                existingSchedule.StartDate = schedule.StartDate;
                existingSchedule.EndDate = schedule.EndDate;

                await _context.SaveChangesAsync();
                return existingSchedule;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nell'aggiornamento della programmazione con id {schedule.Id}: {e.Message}");
            }
        }

        public async Task<List<Schedule>> GetSchedulesByYear(int year)
        {
            return await _context.Schedules
                .Where(s => s.StartDate.Year == year)
                .ToListAsync();
        }

        public async Task<List<ScheduleDto>> GetSchedulesByYearFromThisWeek(int year)
        {
            DateTime firstDayOfWeek = DateTimeHelper.GetStartOfWeek(DateTime.Now);
            var lastDayOfYear = new DateTime(year, 12, 31);

            // Ottieni tutti i schedule per il periodo specificato
            var schedules = await _context.Schedules
                .Where(s => s.StartDate >= firstDayOfWeek && s.StartDate <= lastDayOfYear)
                .ToListAsync();

            var movieIds = schedules.Select(s => s.MovieId).Distinct().ToList();
            var roomIds = schedules.Select(s => s.RoomId).Distinct().ToList();

            // Ottieni i dettagli dei film e delle sale in un'unica chiamata
            var movies = await _context.Movies
                .Where(m => movieIds.Contains(m.Id))
                .ToDictionaryAsync(m => m.Id);


            var rooms = await _context.Rooms
                .Where(r => roomIds.Contains(r.Id))
                .ToDictionaryAsync(r => r.Id);

            // Mappa i dati nei DTO
            var scheduleDtos = schedules.Select(s => new ScheduleDto
            {
                ScheduleId = s.Id,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                Movie = movies.ContainsKey(s.MovieId) ? new MovieDto
                {
                    MovieId = movies[s.MovieId].Id,
                    Title = movies[s.MovieId].Title,
                    Year = movies[s.MovieId].Year,
                    Runtime = movies[s.MovieId].Runtime,
                } : null,
                Room = rooms.ContainsKey(s.RoomId) ? new RoomDto
                {
                    RoomId = rooms[s.RoomId].Id,
                    Name = rooms[s.RoomId].Name,
                    Capacity = rooms[s.RoomId].Capacity,
                    IsIMAX = rooms[s.RoomId].IsIMAX,
                } : null
            }).ToList();

            return scheduleDtos;
        }
    }
}