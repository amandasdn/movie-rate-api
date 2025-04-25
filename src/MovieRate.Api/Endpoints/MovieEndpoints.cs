using MediatR;
using MovieRate.Application.Features.Movies.Queries;
using MovieRate.ExternalService.TMDB.DTOs;

namespace MovieRate.Api.Endpoints;

public static class MovieEndpoints
{
    private const string ENDPOINT_TAG_NAME = "Movies";

    public static void MapMovieEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/movies/popular", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetPopularMoviesQuery());
            return Results.Ok(result);
        })
        .WithName("GetPopularMovies")
        .WithTags(ENDPOINT_TAG_NAME)
        .Produces<TmdbPopularMoviesResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithSummary("Popular movies")
        .WithDescription("Get a list of movies ordered by popularity.")
        .WithOpenApi();
    }
}
