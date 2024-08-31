using System.ComponentModel.DataAnnotations;

namespace CineMilleCodeChallenge.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
