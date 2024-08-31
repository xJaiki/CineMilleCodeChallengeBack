using System.ComponentModel.DataAnnotations;

namespace CineMilleCodeChallenge.Models
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public required int Year { get; set; }
        public required int Runtime { get; set; }
        public string? Genres { get; set; } = "";
        public string? Director { get; set; } = "";
        public string? Actors { get; set; } = "";
        public string? Plot { get; set; } = "";
        public string? PosterUrl { get; set; } = "";
    }
}
