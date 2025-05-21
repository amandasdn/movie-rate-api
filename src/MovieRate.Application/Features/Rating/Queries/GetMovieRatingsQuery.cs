using MediatR;
using MovieRate.Application.Features.Rating.DTOs;

namespace MovieRate.Application.Features.Rating.Queries;

public record GetMovieRatingsQuery(int MovieId) : IRequest<List<MovieRatingDto>>;
