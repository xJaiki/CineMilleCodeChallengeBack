using CineMilleCodeChallenge.Models;

namespace CineMilleCodeChallenge.Repositories
{
    public interface IScheduleRepository
    {
        Task<Schedule> GetScheduleById(int id);
        Task<Schedule> CreateSchedule(Schedule schedule);
        Task<Schedule> UpdateSchedule(Schedule schedule);
        Task<Schedule> DeleteSchedule(int id);
        Task<List<Schedule>> GetScheduleByDateWeek(DateTime date);
        Task<List<Schedule>> GetAllSchedules();
        Task<List<Schedule>> GetSchedulesByYear(int year);
        Task<List<ScheduleDto>> GetSchedulesByYearFromThisWeek(int year);
    }
}
