using Cardinow.Application.Dtos;


namespace Cardinow.Application.IServices;

public interface IGenericService<TDto, TEntity,TDbEntity, TCreateDto, TUpdateDto>
    where TEntity : class
    where TDbEntity : class
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class

{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task AddAsync(TCreateDto model);
    Task UpdateAsync(TUpdateDto model);
    Task DeleteAsync(Guid id);
    Task<TDto> GetByIdAsync(Guid id);

}
