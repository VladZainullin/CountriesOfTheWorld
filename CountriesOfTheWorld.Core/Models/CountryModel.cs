using System.ComponentModel.DataAnnotations;
using CountriesOfTheWorld.Core.Entities;

namespace CountriesOfTheWorld.Core.Models;

public class CountryModel
{
    public string? Name { get; set; }
    public int Area { get; set; }
    public List<City>? Cities { get; set; }
}