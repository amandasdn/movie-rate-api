using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieRate.ExternalService.TMDB.Clients;
using MovieRate.ExternalService.TMDB.Configuration;
using Refit;

namespace MovieRate.ExternalService.TMDB.DependencyInjection;

public static class TmdbCollectionExtensions
{
    public static IServiceCollection AddTmdbDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TmdbSettings>(configuration.GetSection(TmdbSettings.SectionName));

        var tmdbSettings = configuration
            .GetSection(TmdbSettings.SectionName)
            .Get<TmdbSettings>();

        services
            .AddRefitClient<IMovieApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(tmdbSettings!.BaseUrl);
                c.DefaultRequestHeaders.Add("Authorization", $"Bearer {tmdbSettings.ApiKey}");
            });

        return services;
    }
}
