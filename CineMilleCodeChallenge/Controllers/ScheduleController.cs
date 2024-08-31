using CineMilleCodeChallenge.Models;
using CineMilleCodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> CreateSchedule([FromBody] Schedule schedule)
        {
            try
            {
                var createdSchedule = await _scheduleService.CreateSchedule(schedule);
                return Ok(createdSchedule);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<Schedule>> UpdateSchedule([FromBody] Schedule schedule)
        {
            try
            {
                var updatedSchedule = await _scheduleService.UpdateSchedule(schedule);
                return Ok(updatedSchedule);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Schedule>> DeleteSchedule(int id)
        {
            try
            {
                var deletedSchedule = await _scheduleService.DeleteSchedule(id);
                return Ok(deletedSchedule);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetAllSchedules()
        {
            try
            {
                var schedules = await _scheduleService.GetAllSchedules();
                return Ok(schedules);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleById(int id)
        {
            try
            {
                var schedule = await _scheduleService.GetScheduleById(id);
                return Ok(schedule);
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<List<Schedule>>> GetScheduleByDateWeek(string date)
        {
            try
            {
                var schedules = await _scheduleService.GetScheduleByDateWeek(date);
                return Ok(schedules);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("year/{year}")]
        public async Task<ActionResult<List<Schedule>>> GetSchedulesByYear(int year)
        {
            try
            {
                var schedules = await _scheduleService.GetSchedulesByYear(year);
                return Ok(schedules);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("year/fromthisweek/{year}")]
        public async Task<ActionResult<List<Schedule>>> GetSchedulesByYearFromThisWeek(int year)
        {
            try
            {
                var schedules = await _scheduleService.GetSchedulesByYearFromThisWeek(year);
                return Ok(schedules);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
