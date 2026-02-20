using Cardinow.Domain.Enums;
namespace Cardinow.Domain.Entities;
public class Order : BaseEntity
{

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? ExpireDate { get; set; }

    public decimal ShippingCost { get; set; }

    public PackageType PackageType { get; set; }

    public bool VcfOnly { get; set; }

}