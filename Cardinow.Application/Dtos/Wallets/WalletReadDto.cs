using Cardinow.Application.Dtos.Shared;

namespace Cardinow.Application.Dtos.Wallets;
public class WalletReadDto : BaseEntityDto
{
    public Guid UserId { get; set; }
    public decimal Balance { get; set; }
    public decimal TotalSales { get; set; }
}
