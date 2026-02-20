using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Cardinow.DataAccess.Repositories;

public class WalletRepository
    : GenericRepository<Wallet>, IWalletRepository
{
    private readonly AppDbContext _context;

    public WalletRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Wallet?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Wallets
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}