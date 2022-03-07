using System.ComponentModel.DataAnnotations;
using CountriesOfTheWorld.Core.Entities;

namespace CountriesOfTheWorld.Core.Models;

public record class CountryModel
{
    [Required]
    [MaxLength(50)]
    [MinLength(1)]
    public string? Name { get; set; }
    
    [Required]
    [Range(1,100_000_000)]
    public int Area { get; set; }

    public List<City>? Cities { get; set; }
}