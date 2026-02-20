using Microsoft.EntityFrameworkCore;
using Cardinow.Domain.IRepositories;
using Cardinow.Domain.Entities;

public class GenericRepository<T>
    : IGenericRepository<T>
    where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
        => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    public void Update(T entity)
        => _dbSet.Update(entity);

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
    }

    public IQueryable<T> Query()
        => _dbSet.AsQueryable();
}