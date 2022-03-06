using CountriesOfTheWorld.Core.Entities;

namespace CountriesOfTheWorld.Data.Services;

public interface ICountryRepository<in TId>
{
    public Task<IEnumerable<Country?>> GetAllAsync(bool includeCities);
    public Task<Country?> GetByIdAsync(TId id, bool includeCities);
    public Task<Country?> GetByNameAsync(string name, bool includeCities);
}