using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entities;

public class Game
{
    
    public int Id { get; set; }     // Propert 1: Game Id

    [Required]
    [StringLength(50)] //Max length of name should be 50 characters
    public required string Name { get; set; }  //Property 2: Game Name

    [Required]
    [StringLength(20)]//Max length of genre should be 20 characters
    public required string Genre { get; set; } //Property 3: Game Genre

    [Range(1,100)]
    public decimal Price { get; set; } //Property 4: Game Price

    public DateOnly ReleaseDate { get; set; } //Property 5: Release Date of the Game

    [Url]
    [StringLength(100)]
    public string? ImageURI { get; set; } //Property 6: Image URL for game photo
}