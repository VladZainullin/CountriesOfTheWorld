using CountriesOfTheWorld.Core.Entities;

namespace CountriesOfTheWorld.Data.Services;

public interface ICityRepository<in TId> : IBaseOperation<City>
{
    public Task<IEnumerable<City>?> GetAllByCountryId(Guid id);
    public Task<IEnumerable<City?>> GetAllAsync();
    public Task<City?> GetByIdAsync(TId id);
}