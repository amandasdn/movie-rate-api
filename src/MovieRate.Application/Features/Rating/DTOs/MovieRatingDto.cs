namespace MovieRate.Application.Features.Rating.DTOs;

public record MovieRatingDto(int Rating, string? Comment, DateTime CreatedAt);
