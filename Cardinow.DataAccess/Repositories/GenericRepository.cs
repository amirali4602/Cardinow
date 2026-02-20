using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Cardinow.DataAccess.Persistence;
using Cardinow.Domain.IRepositories;

namespace Cardinow.DataAccess.Repositories;

public class GenericRepository<TEntity,TDbEntity>(
    AppDbContext context,
    IMapper mapper) : IGenericRepository<TEntity,TDbEntity> 
    where TEntity : class 
    where TDbEntity : class
{
    private readonly DbSet<TDbEntity> dbSet = context.Set<TDbEntity>();

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var dbEntities = await dbSet.ToListAsync();
        return mapper.Map<IEnumerable<TEntity>>(dbEntities);
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        var dbEntity= await dbSet.FindAsync(id);
        return mapper.Map<TEntity>(dbEntity);

    }

    public async Task AddAsync(TEntity entity)
    {
        var dbEntity = mapper.Map<TDbEntity>(entity);
        await dbSet.AddAsync(dbEntity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        var dbEntity = mapper.Map<TDbEntity>(entity);
        dbSet.Update(dbEntity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity != null)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    
}
