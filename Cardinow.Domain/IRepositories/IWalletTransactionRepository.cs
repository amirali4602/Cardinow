using Cardinow.Domain.Entities;

namespace Cardinow.Domain.IRepositories;

public interface IWalletTransactionRepository
 : IGenericRepository<WalletTransaction>
{
    Task<IReadOnlyList<WalletTransaction>>
        GetByWalletIdAsync(Guid walletId);
}
