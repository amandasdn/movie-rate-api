using Microsoft.EntityFrameworkCore;
using MovieRate.Domain.Entities;
using MovieRate.Infra.Data.Configurations;

namespace MovieRate.Infra.Data;

public class MovieRateDbContext(DbContextOptions<MovieRateDbContext> options) : DbContext(options)
{
    public DbSet<MovieRating> MovieRatings => Set<MovieRating>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieRatingConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
