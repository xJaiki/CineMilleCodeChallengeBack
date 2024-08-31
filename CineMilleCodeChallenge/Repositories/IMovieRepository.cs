using CineMilleCodeChallenge.Models;

namespace CineMilleCodeChallenge.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieById(int id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> DeleteMovie(int id);
        Task<List<Movie>> GetAllMovies();
    }
}
