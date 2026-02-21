using Cardinow.Application.Dtos.Orders;
using Cardinow.Domain.Enums;
namespace Cardinow.Application.IServices;

public interface IOrderService
{
    Task<OrderReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<OrderReadDto>> GetAllAsync();
    Task CreateAsync(CreateOrderDto dto);
    Task UpdateStatusAsync(Guid orderId, OrderStatus status);
    Task SoftDeleteAsync(Guid id);
}
