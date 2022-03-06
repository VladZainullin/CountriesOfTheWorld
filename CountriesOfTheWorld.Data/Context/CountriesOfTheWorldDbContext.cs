using CountriesOfTheWorld.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountriesOfTheWorld.Data.Context;

public class CountriesOfTheWorldDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    
    public CountriesOfTheWorldDbContext(DbContextOptions<CountriesOfTheWorldDbContext> options) 
        : base(options)
    {
        
    }
}