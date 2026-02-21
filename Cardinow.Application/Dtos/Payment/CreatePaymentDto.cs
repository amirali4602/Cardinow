namespace Cardinow.Application.Dtos.Payment;

public class CreatePaymentDto
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Authority { get; set; } // ZarinPal
    public bool IsVerified { get; set; } = false; 
}
