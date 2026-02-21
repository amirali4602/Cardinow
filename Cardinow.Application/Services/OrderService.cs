using AutoMapper;
using Cardinow.Application.Dtos.Orders;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.Enums;
using Cardinow.Domain.IRepositories;

namespace Cardinow.Application.Services;
public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IGenericRepository<Order> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
    {
        var orders = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
    }

    public async Task<OrderReadDto?> GetByIdAsync(Guid id)
    {
        var order = await _repository.GetByIdAsync(id);
        return order == null ? null : _mapper.Map<OrderReadDto>(order);
    }

    public async Task CreateAsync(CreateOrderDto dto)
    {
        var order = _mapper.Map<Order>(dto);
        order.CreatedAt = DateTime.UtcNow;

        await _repository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateStatusAsync(Guid orderId, OrderStatus status)
    {
        var order = await _repository.GetByIdAsync(orderId);
        if (order == null) throw new Exception("Order not found");

        order.Status = status;
        order.UpdatedAt = DateTime.UtcNow;

        _repository.Update(order);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        var order = await _repository.GetByIdAsync(id);
        if (order == null) throw new Exception("Order not found");

        order.IsDeleted = true;
        order.DeletedAt = DateTime.UtcNow;

        _repository.Update(order);
        await _unitOfWork.SaveChangesAsync();
    }
}