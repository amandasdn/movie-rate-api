using MediatR;

namespace MovieRate.Application.Features.Rating.Commands;

public record CreateMovieRatingCommand(int MovieId, int Rating, string? Comment) : IRequest<Guid>;
