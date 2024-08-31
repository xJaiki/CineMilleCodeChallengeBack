using CineMilleCodeChallenge.Models;
using CineMilleCodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom([FromBody] Room room)
        {
            try
            {
                var createdRoom = await _roomService.CreateRoom(room);
                return Ok(createdRoom);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<Room>> UpdateRoom([FromBody] Room room)
        {
            try
            {
                var updatedRoom = await _roomService.UpdateRoom(room);
                return Ok(updatedRoom);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            try
            {
                var deletedRoom = await _roomService.DeleteRoom(id);
                return Ok(deletedRoom);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetAllRooms()
        {
            try
            {
                var rooms = await _roomService.GetAllRooms();
                return Ok(rooms);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            try
            {
                var room = await _roomService.GetRoomById(id);
                return Ok(room);
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("available")]
        public async Task<ActionResult<List<Room>>> GetAvailableRooms([FromQuery] string date)
        {
            try
            {
                var rooms = await _roomService.GetAvailableRooms(date);
                return Ok(rooms);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
