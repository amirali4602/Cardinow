using Cardinow.Domain.Entities;
using Cardinow.Domain.Enums;

namespace Cardinow.Domain.IRepositories;

public interface IOrderRepository
    : IGenericRepository<Order>
{
    Task<IReadOnlyList<Order>>
        GetUserOrdersAsync(Guid userId);

    Task<IReadOnlyList<Order>>
        GetByStatusAsync(OrderStatus status);
}