using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

/// <summary>
/// Interface defining operations for game data persistence
/// </summary>
public interface IGamesRepository
{
  /// <summary>Creates a new game in the repository</summary>
  Task CreateAsync(Game game);

  /// <summary>Deletes a game by its ID</summary>
  Task DeleteAsync(int id);

  /// <summary>Retrieves a specific game by its ID</summary>
  Task<Game?> GetAsync(int id);

  /// <summary>Retrieves all games from the repository</summary>
  Task<IEnumerable<Game>> GetAllAsync();

  /// <summary>Updates an existing game's information</summary>
  Task UpdateAsync(Game updatedGame);
}
