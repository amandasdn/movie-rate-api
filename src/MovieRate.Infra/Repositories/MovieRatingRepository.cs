using Microsoft.EntityFrameworkCore;
using MovieRate.Domain.Entities;
using MovieRate.Domain.Interfaces.Repositories;
using MovieRate.Infra.Data;

namespace MovieRate.Infra.Repositories;

public class MovieRatingRepository(MovieRateDbContext context) : IMovieRatingRepository
{
    public async Task<IEnumerable<MovieRating>> GetByMovieIdAsync(int movieId, CancellationToken cancellationToken)
    {
        return await context.MovieRatings
            .Where(x => x.MovieId == movieId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Guid> CreateAsync(MovieRating rating, CancellationToken cancellationToken)
    {
        context.MovieRatings.Add(rating);
        await context.SaveChangesAsync(cancellationToken);
        return rating.Id;
    }
}