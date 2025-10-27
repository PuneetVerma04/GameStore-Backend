using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGameRepository : IGamesRepository
{
    private readonly List<Game> games = new() {
        new Game{
        Id = 1,
        Name = "Minecraft",
        Genre = "Sandbox",
        Price = 29.99m,
        ReleaseDate = new DateOnly(2011, 11, 18),
        ImageURI = "https://placehold.co/300x200"
        },

        new Game{
        Id = 2,
        Name = "Grand Theft Auto V",
        Genre = "Action",
        Price = 29.99m,
        ReleaseDate = new DateOnly(2013, 9, 17),
        ImageURI = "https://placehold.co/300x200"
        },

        new Game{
        Id = 3,
        Name = "Tetris",
        Genre = "Puzzle",
        Price = 0m,
        ReleaseDate = new DateOnly(1984, 6, 6),
        ImageURI = "https://placehold.co/300x200"
        }
    };

    public async Task<IEnumerable<Game>> GetAllAsync()//return all the games
    {
        return await Task.FromResult<IEnumerable<Game>>(games);
    }

    public async Task<Game?> GetAsync(int id)
    {
        var game = games.Find(game => game.Id == id);  //Creating an object of type Game with the given id and checking if it exists
        return await Task.FromResult(game);
    }

    public async Task CreateAsync(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1; //Setting the Id of the new game to the maximum Id in the list + 1
        games.Add(game);

        await Task.CompletedTask; // Return a completed task
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
        
        await Task.CompletedTask;
    }

}