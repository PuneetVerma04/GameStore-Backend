using GameStore.Api.Endpoints;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace GameStore.Api.Repositories;

public class EntitFrameworkGamesRepo : IGamesRepository
{
    private readonly GameStoreContext dbContext;

    public EntitFrameworkGamesRepo(GameStoreContext context)
    {
        this.dbContext = context;
    }
    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await dbContext.Game.AsNoTracking().ToListAsync();
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await dbContext.Game.FindAsync(id);
    }
    public async Task CreateAsync(Game game)
    {
        dbContext.Game.Add(game);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        dbContext.Game.Update(updatedGame); //Using the Update method to update the game in the database
        await dbContext.SaveChangesAsync(); //Saving the changes to the database
    }
    public async Task DeleteAsync(int id)
    {
        await dbContext.Game.Where(game => game.Id == id)
            .ExecuteDeleteAsync(); //Using the ExecuteDelete method to delete the game with the given id 
    }
}