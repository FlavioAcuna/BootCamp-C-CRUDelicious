#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Chef { get; set; }
    [Required]
    [Range(1, 5)]
    public int Tastinness { get; set; }
    [Required]
    [Range(1, Double.PositiveInfinity)]
    public int Calories { get; set; }
    [Required]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdateAt { get; set; } = DateTime.Now;
}