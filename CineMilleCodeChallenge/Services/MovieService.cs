using CineMilleCodeChallenge.Models;
using CineMilleCodeChallenge.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineMilleCodeChallenge.Services
{
    public class MovieService(IMovieRepository movieRepository) : IMovieService
    {
        private readonly IMovieRepository _movieRepository = movieRepository;

        public Task<Movie> CreateMovie(Movie movie)
        {
            return _movieRepository.CreateMovie(movie);
        }

        public Task<Movie> DeleteMovie(int id)
        {
            return _movieRepository.DeleteMovie(id);
        }

        public Task<List<Movie>> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Task<Movie> GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            return _movieRepository.UpdateMovie(movie);
        }
    }
}
