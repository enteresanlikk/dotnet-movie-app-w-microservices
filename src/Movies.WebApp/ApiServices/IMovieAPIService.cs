using Movies.WebApp.Models;
using Movies.WebApp.ViewModels;

namespace Movies.WebApp.ApiServices;

public interface IMovieAPIService
{
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(int id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
}
