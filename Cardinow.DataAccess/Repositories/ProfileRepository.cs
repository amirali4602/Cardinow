using Microsoft.EntityFrameworkCore;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.DataAccess.Repositories;

public class ProfileRepository
    : GenericRepository<Profile>, IProfileRepository
{
    private readonly AppDbContext _context;

    public ProfileRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Profile?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Profiles
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}