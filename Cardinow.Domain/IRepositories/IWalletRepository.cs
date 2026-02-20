using Cardinow.Domain.Entities;

namespace Cardinow.Domain.IRepositories;

public interface IWalletRepository
: IGenericRepository<Wallet>
{
    Task<Wallet?> GetByUserIdAsync(Guid userId);
}
