using MediatR;
using MovieRate.Application.Services.Movies;
using MovieRate.ExternalService.TMDB.DTOs;

namespace MovieRate.Application.Features.Movies.Queries;

public class GetPopularMoviesHandler(IMovieService movieService) : IRequestHandler<GetPopularMoviesQuery, TmdbPopularMoviesResponse>
{
    public async Task<TmdbPopularMoviesResponse> Handle(GetPopularMoviesQuery request, CancellationToken cancellationToken)
    {
        return await movieService.GetPopularMoviesAsync();
    }
}
