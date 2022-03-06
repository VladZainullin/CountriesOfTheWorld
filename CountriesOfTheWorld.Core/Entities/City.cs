namespace CountriesOfTheWorld.Core.Entities;

public record class City
{
    public Guid Id { get; init; }
    public string Name { get; set; } = null!;
    public Guid CountryId { get; set; }
}