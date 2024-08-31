using CineMilleCodeChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Services
{
    public interface IScheduleService
    {
        Task<Schedule> CreateSchedule(Schedule schedule);
        Task<Schedule> UpdateSchedule(Schedule schedule);
        Task<Schedule> DeleteSchedule(int id);
        Task<Schedule> GetScheduleById(int id);
        Task<List<Schedule>> GetScheduleByDateWeek(string date);
        Task<List<Schedule>> GetAllSchedules();
        Task<List<Schedule>> GetSchedulesByYear(int year);
        Task<List<ScheduleDto>> GetSchedulesByYearFromThisWeek(int year);
    }
}
