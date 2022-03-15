using System.ComponentModel.DataAnnotations;

namespace CountriesOfTheWorld.Core.Models;

public record class CityModel
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public Guid CountryId { get; set; }
}