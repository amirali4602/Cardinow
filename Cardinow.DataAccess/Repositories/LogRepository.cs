using Microsoft.EntityFrameworkCore;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;
using Cardinow.DataAccess.Persistence;

namespace Cardinow.DataAccess.Repositories;

public class LogRepository
    :GenericRepository<Log>, ILogRepository
{
    private readonly AppDbContext _context;

    public LogRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Log>>
        GetUserLogsAsync(Guid userId)
    {
        return await _context.Logs
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Timestamp)
            .ToListAsync();
    }
}