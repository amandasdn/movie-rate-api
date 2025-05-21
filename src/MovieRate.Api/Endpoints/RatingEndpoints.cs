using MediatR;
using MovieRate.Application.Features.Rating.Commands;
using MovieRate.Application.Features.Rating.Queries;
using MovieRate.ExternalService.TMDB.DTOs;

namespace MovieRate.Api.Endpoints;

public static class RatingEndpoints
{
    private const string ENDPOINT_TAG_NAME = "Ratings";

    public static void MapRatingEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/ratings/{movieId}", async (int movieId, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetMovieRatingsQuery(movieId));
            return Results.Ok(result);
        })
        .WithName("GetMovieRatings")
        .WithTags(ENDPOINT_TAG_NAME)
        .Produces<TmdbPopularMoviesResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithSummary("Movie Ratings")
        .WithDescription("Get a list of movie ratings.")
        .WithOpenApi();

        app.MapPost("/ratings/{movieId}", async (int movieId, CreateMovieRatingCommand body, IMediator mediator) =>
        {
            if (movieId != body.MovieId) return Results.BadRequest("MovieId mismatch.");
            var id = await mediator.Send(body);
            return Results.Created($"/movies/{movieId}/ratings/{id}", id);
        })
        .WithName("PostMovieRatings")
        .WithTags(ENDPOINT_TAG_NAME)
        .Produces<Guid>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);
    }
}
