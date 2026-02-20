using Cardinow.Application.Dtos.Shared;
using Cardinow.Domain.Enums;

namespace Cardinow.Application.Dtos.Wallets;
public class WalletTransactionDto : BaseEntityDto
{
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public string Reason { get; set; }
}