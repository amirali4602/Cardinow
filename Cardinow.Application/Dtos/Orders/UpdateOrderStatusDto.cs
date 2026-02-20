using Cardinow.Domain.Enums;

namespace Cardinow.Application.Dtos.Orders;

public class UpdateOrderStatusDto //Admin Only
{
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }

}
