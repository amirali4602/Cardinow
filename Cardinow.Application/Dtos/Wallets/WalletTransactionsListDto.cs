namespace Cardinow.Application.Dtos.Wallets;

public class WalletTransactionsListDto
{
    public decimal Balance { get; set; }
    public ICollection<WalletTransactionDto> Transactions { get; set; }
}
