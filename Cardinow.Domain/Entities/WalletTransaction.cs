using Cardinow.Domain.Enums;

namespace Cardinow.Domain.Entities;
public class WalletTransaction : BaseEntity
{
    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public string Reason { get; set; }
}