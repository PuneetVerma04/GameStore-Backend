using GameStore.Api.Data;
using GameStore.Api.Endpoints;

// Main entry point for the application
var builder = WebApplication.CreateBuilder(args);

// Register repositories and database context
builder.Services.AddRepos(builder.Configuration);

// Build the application
var app = builder.Build();

// Initialize the database and apply any pending migrations
await app.Services.InitializeDb();

// Configure endpoints for games and genres
app.MapGameEndopoints();
app.MapGenreEndpoint();

// Start the application
app.Run();
