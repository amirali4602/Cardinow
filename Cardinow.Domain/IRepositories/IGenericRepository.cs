using Cardinow.Domain.Entities;

namespace Cardinow.Domain.IRepositories;

public interface IGenericRepository<T>
    where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity); // Soft delete

    IQueryable<T> Query(); 
}
