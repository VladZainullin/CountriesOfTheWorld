using CountriesOfTheWorld.Core.Entities;

namespace CountriesOfTheWorld.Data.Services;

public interface ICityRepository
{
    public Task<IEnumerable<Country>> GetAllAsync();
    public Task<Country> GetByIdAsync(Guid id);
}