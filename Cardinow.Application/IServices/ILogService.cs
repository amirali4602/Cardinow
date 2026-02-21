using Cardinow.Application.Dtos.Logs;

namespace Cardinow.Application.IServices;
public interface ILogService
{
    Task<IEnumerable<LogReadDto>> GetAllAsync();
    Task AddLogAsync(LogReadDto dto);
}
