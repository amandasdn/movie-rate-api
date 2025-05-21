using MediatR;
using MovieRate.Application.Features.Rating.DTOs;
using MovieRate.Domain.Interfaces.Repositories;

namespace MovieRate.Application.Features.Rating.Queries;

public class GetMovieRatingsHandler(IMovieRatingRepository repository) : IRequestHandler<GetMovieRatingsQuery, List<MovieRatingDto>>
{
    public async Task<List<MovieRatingDto>> Handle(GetMovieRatingsQuery request, CancellationToken cancellationToken)
    {
        var ratings = await repository.GetByMovieIdAsync(request.MovieId, cancellationToken);
        return ratings.Select(r => new MovieRatingDto(r.Rating, r.Comment, r.CreatedAt)).ToList();
    }
}
