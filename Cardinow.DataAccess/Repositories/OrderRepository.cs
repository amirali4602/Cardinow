
using Cardinow.Domain.Entities;
using Cardinow.Domain.Enums;
using Cardinow.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Cardinow.DataAccess.Repositories;

public class OrderRepository
    : GenericRepository<Order>, IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Order>>
        GetUserOrdersAsync(Guid userId)
    {
        return await _context.Orders
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Order>>
        GetByStatusAsync(OrderStatus status)
    {
        return await _context.Orders
            .Where(x => x.Status == status)
            .ToListAsync();
    }
}
