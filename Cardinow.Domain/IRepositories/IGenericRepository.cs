namespace Cardinow.Domain.IRepositories;

public interface IGenericRepository <TEntity, TDbEntity> 
    where TEntity : class 
    where TDbEntity : class
{
    Task <IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
    Task<TEntity> GetByIdAsync(Guid id);
}
