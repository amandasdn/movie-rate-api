using Microsoft.Extensions.DependencyInjection;
using MovieRate.Domain.Interfaces.Repositories;
using MovieRate.Infra.Repositories;

namespace MovieRate.Infra.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfraDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMovieRatingRepository, MovieRatingRepository>();

        return services;
    }
}
