using System.ComponentModel.DataAnnotations;

namespace CineMilleCodeChallenge.Models
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsIMAX { get; set; }
    }
}
