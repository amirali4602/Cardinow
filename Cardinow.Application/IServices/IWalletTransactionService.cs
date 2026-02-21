using Cardinow.Application.Dtos.Wallets;


namespace Cardinow.Application.IServices;

public interface IWalletTransactionService
{
    Task<WalletTransactionsListDto> GetTransactionsByUserIdAsync(Guid userId);
}
