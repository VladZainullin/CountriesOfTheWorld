using System.ComponentModel.DataAnnotations;

namespace CountriesOfTheWorld.Core.Models;

public record class CityModel
{
    public Guid Id { get; init; }
    [Required]
    [MaxLength(30)]
    [MinLength(1)]
    public string? Name { get; set; }
    public Guid CountryId { get; set; }
}