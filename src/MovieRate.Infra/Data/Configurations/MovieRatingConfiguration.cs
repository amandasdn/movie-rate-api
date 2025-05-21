using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRate.Domain.Entities;

namespace MovieRate.Infra.Data.Configurations;

public class MovieRatingConfiguration : IEntityTypeConfiguration<MovieRating>
{
    public void Configure(EntityTypeBuilder<MovieRating> builder)
    {
        builder.ToTable("MovieRatings");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.MovieId).IsRequired();
        builder.Property(x => x.Rating).IsRequired();
        builder.Property(x => x.Comment).HasMaxLength(1000);
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}
