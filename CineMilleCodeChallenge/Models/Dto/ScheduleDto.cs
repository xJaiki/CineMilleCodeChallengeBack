using CineMilleCodeChallenge.Models;

public class ScheduleDto
{
    public int ScheduleId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MovieDto? Movie { get; set; }
    public RoomDto? Room { get; set; }
}