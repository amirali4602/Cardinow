
using Cardinow.Application.Dtos.Products;

namespace Cardinow.Application.IServices;

public interface IProductService
{
    Task<ProductReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProductReadDto>> GetAllAsync();
    Task CreateAsync(CreateProductDto dto);
    Task UpdateAsync(Guid id, UpdateProductDto dto);
    Task SoftDeleteAsync(Guid id);
}
