using GameStore.Api.DTOs;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

/// <summary>
/// Static class containing endpoint definitions for game-related operations
/// </summary>
public static class GamesEndpoints
{
  // Constant for the GetGame endpoint name, used for route generation
  const string GetGameEndPointName = "GetGame";

  /// <summary>
  /// Extension method to map all game-related endpoints
  /// </summary>
  /// <param name="routes">The endpoint route builder instance</param>
  /// <returns>A configured RouteGroupBuilder for games endpoints</returns>
  public static RouteGroupBuilder MapGameEndopoints(this IEndpointRouteBuilder routes)
  {
    // Create a group of routes under "/games" path with automatic parameter validation
    var group = routes.MapGroup("/games").WithParameterValidation();

    // GET /games - Retrieves all games
    group.MapGet("/", async (IGamesRepository repository) =>
    {
      // Get all games and convert them to DTOs
      return (await repository.GetAllAsync()).Select(game => game.AsDto());
    });

    // GET /games/{id} - Retrieves a specific game by ID
    group.MapGet("/{id}", async (IGamesRepository repository, int id) =>
    {
      Game? game = await repository.GetAsync(id);
      // Return 200 OK with game data if found, 404 Not Found otherwise
      return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
    }).WithName(GetGameEndPointName);

    // POST /games - Creates a new game
    group.MapPost("/", async (IGamesRepository repository, CreateGameDTO gameDTO) =>
    {
      // Create new game entity from DTO
      Game game = new()
      {
        Name = gameDTO.Name,
        Genre = gameDTO.Genre,
        Price = gameDTO.Price,
        ReleaseDate = gameDTO.ReleaseDate,
        ImageURI = gameDTO.ImageUri
      };

      // Save the new game to repository
      await repository.CreateAsync(game);

      // Return 201 Created response with the location header pointing to the new resource
      return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
    });

    // PUT /games/{id} - Updates an existing game
    group.MapPut("/{id}", async (IGamesRepository repository, int id, UpdateGameDTO updatedGameDTO) =>
    {
      // Find the existing game
      Game? existingGame = await repository.GetAsync(id);

      if (existingGame is null)
      {
        return Results.NotFound();
      }

      // Update game properties from DTO
      existingGame.Name = updatedGameDTO.Name;
      existingGame.Genre = updatedGameDTO.Genre;
      existingGame.Price = updatedGameDTO.Price;
      existingGame.ReleaseDate = updatedGameDTO.ReleaseDate;
      existingGame.ImageURI = updatedGameDTO.ImageUri;

      // Save changes to repository
      await repository.UpdateAsync(existingGame);

      // Return 204 No Content to indicate successful update
      return Results.NoContent();
    });

    // DELETE /games/{id} - Deletes a specific game
    group.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
    {
      Game? gameToDelete = await repository.GetAsync(id);

      if (gameToDelete is not null)
      {
        await repository.DeleteAsync(id);
      }

      // Return 204 No Content regardless of whether game existed
      return Results.NoContent();
    });

    return group;
  }

  /// <summary>
  /// Extension method to map genre-related endpoints
  /// </summary>
  /// <param name="routes">The endpoint route builder instance</param>
  public static void MapGenreEndpoint(this IEndpointRouteBuilder routes)
  {
    // GET /genres - Retrieves all unique genres
    routes.MapGet("/genres", async (IGamesRepository repository) =>
    {
      // Get all games, extract unique genres, sort them, and return as a list
      var genres = (await repository.GetAllAsync())
              .Select(g => g.Genre)
              .Distinct()
              .OrderBy(g => g)
              .ToList();

      return Results.Ok(genres);
    });
  }
}