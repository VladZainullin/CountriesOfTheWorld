using CountriesOfTheWorld.Core.Entities;

namespace CountriesOfTheWorld.Data.Services;

public interface ICountryRepository
{
    public Task<IEnumerable<Country>> GetAllAsync();
    public Task<Country> GetByIdAsync(Guid id);
    public Task<Country> GetByNameAsync(string name);
}

public interface ICityRepository
{
    public Task<IEnumerable<Country>> GetAllAsync();
    public Task<Country> GetByIdAsync(Guid id);
}