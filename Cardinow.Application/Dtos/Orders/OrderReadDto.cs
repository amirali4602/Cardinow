using Cardinow.Application.Dtos.Shared;
using Cardinow.Domain.Enums;
namespace Cardinow.Application.Dtos.Orders;

public class OrderReadDto : BaseEntityDto
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? ExpireDate { get; set; }

    public decimal ShippingCost { get; set; }

    public PackageType PackageType { get; set; }

    public bool VcfOnly { get; set; }

}
