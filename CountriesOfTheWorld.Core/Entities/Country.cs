namespace CountriesOfTheWorld.Core.Entities;

public class Country
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public int Area { get; set; }

    public List<City>? Cities { get; set; }
}