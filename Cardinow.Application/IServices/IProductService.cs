
using Cardinow.Application.Dtos.Products;

namespace Cardinow.Application.IServices;

public interface IProductService
{
    Task<IReadOnlyList<ProductReadDto>> GetAllAsync();
    Task<ProductReadDto?> GetByIdAsync(Guid id);
    Task CreateAsync(CreateProductDto dto);
    Task UpdateAsync(Guid id, UpdateProductDto dto);
    Task DeleteAsync(Guid id);
}
