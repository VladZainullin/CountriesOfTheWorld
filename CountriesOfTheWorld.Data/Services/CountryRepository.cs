using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CountriesOfTheWorld.Data.Services;

public class CountryRepository : ICountryRepository<Guid>
{
    private readonly CountriesOfTheWorldDbContext _context;

    public CountryRepository(CountriesOfTheWorldDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Country?>> GetAllAsync(bool includeCities)
    {
        IQueryable<Country> countries = _context.Countries;
        if (includeCities)
        {
            return await countries
                .Include(c => c.Cities)
                .ToListAsync();
        }
        return await countries.ToListAsync();
    }

    public async Task<Country?> GetByIdAsync(Guid id, bool includeCities)
    {
        var countries = _context.Countries.Where(c => c.Id == id);
        if (includeCities)
        {
            return await countries
                .Include(c => c.Cities)
                .FirstOrDefaultAsync();
        }
        return await countries.FirstOrDefaultAsync();
    }

    public async Task<Country?> GetByNameAsync(string name, bool includeCities)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        var countries = _context.Countries.Where(c => c.Name == name);
        if (includeCities)
        {
            return await countries
                .Include(c => c.Cities)
                .FirstOrDefaultAsync();
        }
        return await countries.FirstOrDefaultAsync();
    }

    public async Task AddAsync(Country country)
    {
        await _context.AddAsync(country);
    }

    public void Delete(Country country)
    {
        _context.Remove(country);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public void Update(Country country)
    {
        _context.Update(country);
    }
}