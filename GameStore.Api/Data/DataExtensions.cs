using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

/// <summary>
/// Extension methods for configuring data access and database initialization
/// </summary>
public static class DataExtensions
{
    /// <summary>
    /// Initializes the database and applies any pending migrations
    /// </summary>
    /// <param name="services">The application's service provider</param>
    public static async Task InitializeDb(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }

    /// <summary>
    /// Configures database context and repository services
    /// </summary>
    /// <param name="services">The service collection to add services to</param>
    /// <param name="configuration">Application configuration</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddRepos(this IServiceCollection services, IConfiguration configuration)
    {
        // Get connection string from configuration
        var conString = configuration.GetConnectionString("GameStoreDb");

        // Add DB context with SQL Server
        services.AddSqlServer<GameStoreContext>(conString);

        // Register the repository implementation
        services.AddScoped<IGamesRepository, EntitFrameworkGamesRepo>();

        return services;
    }
}