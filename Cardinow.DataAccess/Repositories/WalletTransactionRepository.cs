using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Cardinow.DataAccess.Repositories;
public class WalletTransactionRepository
    : GenericRepository<WalletTransaction>,
      IWalletTransactionRepository
{
    private readonly AppDbContext _context;

    public WalletTransactionRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<WalletTransaction>>
        GetByWalletIdAsync(Guid walletId)
    {
        return await _context.WalletTransactions
            .Where(x => x.WalletId == walletId)
            .ToListAsync();
    }
}