
using Cardinow.Domain.Entities;

namespace Cardinow.Domain.IRepositories;

public interface IProfileRepository
    : IGenericRepository<Profile>
{
    Task<Profile?> GetByUserIdAsync(Guid userId);
}
