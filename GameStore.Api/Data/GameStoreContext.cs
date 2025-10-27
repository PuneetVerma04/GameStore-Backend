using System.Reflection;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

/// <summary>
/// Database context for the game store application
/// </summary>
public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
    {
    }

    /// <summary>
    /// DbSet representing the games table in the database
    /// </summary>
    public DbSet<Game> Game => Set<Game>();

    /// <summary>
    /// Configures the database model using configurations from assembly
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply all entity configurations found in the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}