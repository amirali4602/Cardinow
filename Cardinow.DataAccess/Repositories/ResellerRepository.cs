using Microsoft.EntityFrameworkCore;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.DataAccess.Repositories;

public class ResellerRepository
    : GenericRepository<Reseller>, IResellerRepository
{
    private readonly AppDbContext _context;

    public ResellerRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Reseller?> GetByDomainAsync(string domain)
    {
        return await _context.Resellers
            .FirstOrDefaultAsync(x => x.Domain == domain);
    }
}