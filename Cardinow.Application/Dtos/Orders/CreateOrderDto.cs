using Cardinow.Domain.Enums;

namespace Cardinow.Application.Dtos.Orders;

public class CreateOrderDto
{
    public Guid ProductId { get; set; }

    public PackageType PackageType { get; set; }

    public bool VcfOnly { get; set; }

}
