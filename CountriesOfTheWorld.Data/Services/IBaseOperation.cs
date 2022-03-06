namespace CountriesOfTheWorld.Data.Services;

public interface IBaseOperation<in T>
{
    public Task AddAsync(T entity);

    public void Delete(T entity);

    public Task SaveChangesAsync();
}