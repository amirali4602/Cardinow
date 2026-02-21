using AutoMapper;
using Cardinow.Application.Dtos.Users;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.Application.Services;

public class UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
    private readonly IGenericRepository<User> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<UserAdminReadDto>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserAdminReadDto>>(users);
    }

    public async Task<UserAdminReadDto?> GetByIdAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        return user == null ? null : _mapper.Map<UserAdminReadDto>(user);
    }

    public async Task<UserAdminReadDto> CreateAsync(RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        user.CreatedAt = DateTime.UtcNow;

        await _repository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<UserAdminReadDto>(user);
    }

    public async Task VerifyCodeAsync(VerifyCodeDto dto)
    {
        // TODO: منطق Verify شماره موبایل / ایمیل
    }

    public async Task UpdateRoleAsync(UpdateUserRoleDto dto)
    {
        var user = await _repository.GetByIdAsync(dto.Id) ?? throw new Exception("User not found");
        user.Role = dto.Role;
        user.UpdatedAt = DateTime.UtcNow;

        _repository.Update(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task BlockUserAsync(BlockUserDto dto)
    {
        var user = await _repository.GetByIdAsync(dto.Id) ?? throw new Exception("User not found");
        user.IsBlocked = true;
        user.UpdatedAt = DateTime.UtcNow;

        _repository.Update(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
