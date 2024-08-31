using CineMilleCodeChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Services
{
    public interface IMovieService
    {
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> DeleteMovie(int id);
        Task<Movie> GetMovieById(int id);
        Task<List<Movie>> GetAllMovies();
    }
}
