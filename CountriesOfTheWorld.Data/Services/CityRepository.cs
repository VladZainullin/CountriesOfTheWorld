using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CountriesOfTheWorld.Data.Services;

public class CityRepository : ICityRepository<Guid>
{
    private readonly CountriesOfTheWorldDbContext _context;

    public CityRepository(CountriesOfTheWorldDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<City>?> GetAllByCountryId(Guid countryId)
    {
        return await _context.Cities
            .Where(c => c.CountryId == countryId)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<City?>> GetAllAsync()
    {
        return await _context.Cities
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<City?> GetByIdAsync(Guid cityId)
    {
        return await _context.Cities.Where(c => c.Id == cityId).SingleOrDefaultAsync();
    }

    public async Task AddAsync(City country)
    {
        await _context.AddAsync(country);
    }

    public void Delete(City country)
    {
        _context.Remove(country);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public void Update(City country)
    {
        _context.Update(country);
    }
}