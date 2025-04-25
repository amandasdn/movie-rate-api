using MovieRate.ExternalService.TMDB.Clients;
using MovieRate.ExternalService.TMDB.DTOs;

namespace MovieRate.Application.Services.Movies;

public class MovieService(IMovieApi movieApi) : IMovieService
{
    public async Task<TmdbPopularMoviesResponse> GetPopularMoviesAsync()
    {
        return await movieApi.GetPopularMoviesAsync();
    }
}