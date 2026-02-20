namespace Cardinow.Domain.Entities;
public class Wallet : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public decimal Balance { get; set; }
    public decimal TotalSales { get; set; }
    public decimal CashedOut { get; set; }
    public ICollection<WalletTransaction> Transactions { get; set; }
}