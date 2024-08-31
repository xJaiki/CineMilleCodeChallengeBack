using CineMilleCodeChallenge.Data;
using CineMilleCodeChallenge.Helpers;
using CineMilleCodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CineMilleCodeChallenge.Repositories
{
    public class MovieRepository(ApplicationDbContext context) : IMovieRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Movie> CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            try
            {
                var movie = await _context.Movies.FindAsync(id) ?? throw new Exception($"Film con id {id} non trovato");
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return movie;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nella cancellazione del film con id {id}: {e.Message}");
            }
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            try
            {
                Movie existingMovie = await _context.Movies.FindAsync(movie.Id);
                if (existingMovie == null)
                {
                    throw new Exception($"Film con id {movie.Id} non trovato");
                }

                existingMovie.Title = movie.Title;
                existingMovie.Year = movie.Year;
                existingMovie.Runtime = movie.Runtime;
                existingMovie.Genres = movie.Genres;
                existingMovie.Director = movie.Director;
                existingMovie.Actors = movie.Actors;
                existingMovie.Plot = movie.Plot;
                existingMovie.PosterUrl = movie.PosterUrl;

                await _context.SaveChangesAsync();
                return existingMovie;
            }
            catch (Exception e)
            {
                throw new Exception($"Errore nell'aggiornamento del film con id {movie.Id}: {e.Message}");
            }
        }
    }
}
