using CineMilleCodeChallenge.Models;
using CineMilleCodeChallenge.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Services
{
    public class ScheduleService(IScheduleRepository scheduleRepository) : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository = scheduleRepository;
        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            if (schedule.MovieId == null || schedule.RoomId == null)
            {
                throw new Exception("Film e sala obbligatori");
            }

            var existingSchedule = await _scheduleRepository.GetScheduleByDateWeek(schedule.StartDate);
            foreach (var existingScheduledMovie in existingSchedule)
            {
                if (existingScheduledMovie.RoomId == schedule.RoomId)
                {
                    throw new Exception("Sala già occupata");
                }
            }
            return await _scheduleRepository.CreateSchedule(schedule);
        }

        public Task<Schedule> DeleteSchedule(int id)
        {
            return _scheduleRepository.DeleteSchedule(id);    
        }

        public Task<List<Schedule>> GetAllSchedules()
        {
            return _scheduleRepository.GetAllSchedules();
        }

        public Task<Schedule> GetScheduleById(int id)
        {
            return _scheduleRepository.GetScheduleById(id);
        }

        public async Task<Schedule> UpdateSchedule(Schedule schedule)
        {
            if (schedule.MovieId == null || schedule.RoomId == null)
            {
                throw new Exception("Film e sala obbligatori");
            }
            return await _scheduleRepository.UpdateSchedule(schedule);
        }

        public Task<List<Schedule>> GetScheduleByDateWeek(string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            return _scheduleRepository.GetScheduleByDateWeek(dateTime);
        }

        public Task<List<Schedule>> GetSchedulesByYear(int year)
        {
            return _scheduleRepository.GetSchedulesByYear(year);
        }

        public Task<List<ScheduleDto>> GetSchedulesByYearFromThisWeek(int year)
        {
            return _scheduleRepository.GetSchedulesByYearFromThisWeek(year);
        }
    }

}
