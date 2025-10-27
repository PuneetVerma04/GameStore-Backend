using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Api.Data.Configurations;

/// <summary>
/// Entity Framework configuration for the Game entity
/// </summary>
public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        // Configure the Price property to have 5 digits with 2 decimal places
        builder.Property(game => game.Price).HasPrecision(5, 2);
    }
}