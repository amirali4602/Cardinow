namespace Cardinow.Domain.Entities;
public class Payment : BaseEntity
{

    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public decimal Amount { get; set; }

    public string Authority { get; set; } // ZarinPal

    public bool IsVerified { get; set; }

}