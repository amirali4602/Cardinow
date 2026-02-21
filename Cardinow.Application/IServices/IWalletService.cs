using Cardinow.Application.Dtos.Wallets;

namespace Cardinow.Application.IServices;

public interface IWalletService
{
    Task<WalletReadDto?> GetByUserIdAsync(Guid userId);
    Task<CashoutRequestDto> RequestCashoutAsync(Guid userId, decimal amount, string bankInfo);
}