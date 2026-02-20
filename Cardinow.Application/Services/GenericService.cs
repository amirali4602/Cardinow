using AutoMapper;
using Cardinow.Application.Dtos;
using Cardinow.DataAccess.DbEntities;

using Cardinow.Domain.DomainEntities;
using Cardinow.Application.IServices;
using Cardinow.Domain.IRepositories;


namespace Cardinow.Application.Services;

public class GenericService<TDto, TEntity, TDbEntity, TCreateDto, TUpdateDto>(
    IGenericRepository<TEntity,TDbEntity> genericRepository,
    IMapper mapper) : IGenericService<TDto, TEntity,TDbEntity,TCreateDto, TUpdateDto>
    where TEntity : class
    where TDbEntity : class
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
{
    public  async Task AddAsync(TCreateDto model)
    {
        var entity = mapper.Map<TEntity>(model);
        await genericRepository.AddAsync(entity);

    }

    public async Task DeleteAsync(Guid id)
    {
        await genericRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities =  await genericRepository.GetAllAsync();
        return mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto> GetByIdAsync(Guid id)
    {
         var entity=await genericRepository.GetByIdAsync(id);
         return mapper.Map<TDto>(entity);
    }

    public async Task UpdateAsync(TUpdateDto model)
    {
        var entity=mapper.Map<TEntity>(model);
        await genericRepository.UpdateAsync(entity);
    }
}
