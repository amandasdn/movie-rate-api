using MediatR;
using MovieRate.ExternalService.TMDB.DTOs;

namespace MovieRate.Application.Features.Movies.Queries;

public class GetPopularMoviesQuery : IRequest<TmdbPopularMoviesResponse>;