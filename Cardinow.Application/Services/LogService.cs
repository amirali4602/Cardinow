using AutoMapper;
using Cardinow.Application.Dtos.Logs;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.Application.Services;

public class LogService : ILogService
{
    private readonly IGenericRepository<Log> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LogService(IGenericRepository<Log> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LogReadDto>> GetAllAsync()
    {
        var logs = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<LogReadDto>>(logs);
    }

    public async Task AddLogAsync(LogReadDto dto)
    {
        var log = _mapper.Map<Log>(dto);
        log.Timestamp = DateTime.UtcNow;

        await _repository.AddAsync(log);
        await _unitOfWork.SaveChangesAsync();
    }
}