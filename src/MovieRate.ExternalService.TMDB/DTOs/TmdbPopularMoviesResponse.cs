namespace MovieRate.ExternalService.TMDB.DTOs;

public class TmdbPopularMoviesResponse
{
    public int page { get; set; }
    public List<TmdbMovieDTO> results { get; set; } = [];
}

public class TmdbMovieDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public string overview { get; set; }
    public string release_date { get; set; }
}