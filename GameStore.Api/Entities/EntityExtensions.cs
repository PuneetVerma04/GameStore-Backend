using GameStore.Api.DTOs;

namespace GameStore.Api.Entities;

/// <summary>
/// Extension methods for entity-to-DTO conversions
/// </summary>
public static class EntityExtensions
{
    /// <summary>
    /// Converts a Game entity to its DTO representation
    /// </summary>
    /// <param name="game">The game entity to convert</param>
    /// <returns>A GameDto representing the game</returns>
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageURI!
        );
    }
}