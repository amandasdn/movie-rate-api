using MovieRate.ExternalService.TMDB.DTOs;

namespace MovieRate.Application.Services.Movies;

public interface IMovieService
{
    Task<TmdbPopularMoviesResponse> GetPopularMoviesAsync();
}
