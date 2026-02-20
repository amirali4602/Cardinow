
using Cardinow.Domain.Entities;

namespace Cardinow.Domain.IRepositories;

public interface ILogRepository 
    :IGenericRepository<Log>
{
    Task<IReadOnlyList<Log>>
        GetUserLogsAsync(Guid userId);
}
