using MovieRate.Application.Features.Movies.Queries;
using MovieRate.Application.Services.Movies;
using MovieRate.ExternalService.TMDB.Clients;
using MovieRate.ExternalService.TMDB.Configuration;
using Refit;

namespace MovieRate.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMovieRateDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetPopularMoviesQuery).Assembly));

            services.AddScoped<IMovieService, MovieService>();

            services.Configure<TmdbSettings>(
                        configuration.GetSection(TmdbSettings.SectionName));

            var tmdbSettings = configuration
                .GetSection(TmdbSettings.SectionName)
                .Get<TmdbSettings>();

            services.AddRefitClient<IMovieApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(tmdbSettings!.BaseUrl);
                    c.DefaultRequestHeaders.Add("Authorization", $"Bearer {tmdbSettings.ApiKey}");
                });

            return services;
        }
    }
}
