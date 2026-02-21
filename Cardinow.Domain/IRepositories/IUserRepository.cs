using Cardinow.Domain.Entities;
using System.Linq.Expressions;

namespace Cardinow.Domain.IRepositories;

public interface IUserRepository
    : IGenericRepository<User>
{
    Task<User?> GetByPhoneAsync(string phone);

    Task<User?> GetByEmailAsync(string email);
    Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
}
