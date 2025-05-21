using MovieRate.Domain.Entities;

namespace MovieRate.Domain.Interfaces.Repositories;

public interface IMovieRatingRepository
{
    Task<IEnumerable<MovieRating>> GetByMovieIdAsync(int movieId, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(MovieRating rating, CancellationToken cancellationToken);
}
