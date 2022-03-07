namespace CountriesOfTheWorld.Data.Services;

public interface IBaseOperation<in TEntity>
{

    public Task AddAsync(TEntity entity);

    public void Update(TEntity entity);

    public void Delete(TEntity entity);

    public Task SaveChangesAsync();
}