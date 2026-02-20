using Cardinow.Domain.Entities;

namespace Cardinow.Domain.IRepositories;

public interface IUserRepository
    : IGenericRepository<User>
{
    Task<User?> GetByPhoneAsync(string phone);

    Task<User?> GetByEmailAsync(string email);
}
