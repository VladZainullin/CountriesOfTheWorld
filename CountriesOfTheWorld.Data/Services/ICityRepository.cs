using CountriesOfTheWorld.Core.Entities;

namespace CountriesOfTheWorld.Data.Services;

public interface ICityRepository<in TId>
{
    public Task<IEnumerable<City?>> GetAllAsync();
    public Task<City?> GetByIdAsync(TId id);
}