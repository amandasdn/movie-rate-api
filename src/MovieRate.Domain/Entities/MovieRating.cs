namespace MovieRate.Domain.Entities;

public class MovieRating
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int MovieId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
