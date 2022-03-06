namespace CountriesOfTheWorld.Core.Entities;

public record class Country
{
    public Guid Id { get; init; }
    public string Name { get; set; } = null!;
    public int Area { get; set; }

    public List<City> Cities { get; set; } = null!;
}