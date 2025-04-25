namespace MovieRate.ExternalService.TMDB.Configuration;

public class TmdbSettings
{
    public const string SectionName = "TmdbSettings";

    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}
