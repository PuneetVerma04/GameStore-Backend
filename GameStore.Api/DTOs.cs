using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

/// <summary>
/// DTO for returning game information to clients
/// </summary>
public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate,
    string ImageUri
);

/// <summary>
/// DTO for creating a new game with validation rules
/// </summary>
public record CreateGameDTO(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate,
    [Url][StringLength(100)] string ImageUri
);

/// <summary>
/// DTO for updating an existing game with validation rules
/// </summary>
public record UpdateGameDTO(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate,
    [Url][StringLength(100)] string ImageUri
);