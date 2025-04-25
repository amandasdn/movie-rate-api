using MovieRate.Api.Endpoints;

namespace MovieRate.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static void AddEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapMovieEndpoints();
        }
    }
}
