using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cardinow.DataAccess.Repositories;

public class UserRepository
: GenericRepository<User>, IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.PhoneNumber == phone);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }
    public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
    {
        return await _context.Users.AnyAsync(predicate);
    }
}
