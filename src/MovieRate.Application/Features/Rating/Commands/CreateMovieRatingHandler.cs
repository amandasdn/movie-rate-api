using MediatR;
using MovieRate.Domain.Entities;
using MovieRate.Domain.Interfaces.Repositories;

namespace MovieRate.Application.Features.Rating.Commands;

public class CreateMovieRatingHandler(IMovieRatingRepository repository) : IRequestHandler<CreateMovieRatingCommand, Guid>
{
    public async Task<Guid> Handle(CreateMovieRatingCommand request, CancellationToken cancellationToken)
    {
        var rating = new MovieRating
        {
            MovieId = request.MovieId,
            Rating = request.Rating,
            Comment = request.Comment
        };

        return await repository.CreateAsync(rating, cancellationToken);
    }
}

