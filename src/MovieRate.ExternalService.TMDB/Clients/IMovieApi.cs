using Refit;
using MovieRate.ExternalService.TMDB.DTOs;

namespace MovieRate.ExternalService.TMDB.Clients;

public interface IMovieApi
{
    [Get("/movie/popular")]
    Task<TmdbPopularMoviesResponse> GetPopularMoviesAsync();
}