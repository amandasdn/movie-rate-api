using Microsoft.Extensions.DependencyInjection;
using MovieRate.Application.Features.Movies.Queries;
using MovieRate.Application.Services.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRate.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetPopularMoviesQuery).Assembly));

        services.AddScoped<IMovieService, MovieService>();

        return services;
    }
}
