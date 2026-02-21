using AutoMapper;
using Cardinow.Application.Dtos.Users;
using Cardinow.Application.IServices;
using Cardinow.DataAccess.Repositories;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cardinow.Application.Services;

public class UserService(IUserRepository repository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ILogger<UserService> logger,
    IPasswordHasher<User> passwordHasher,
    ITokenService tokenService) : IUserService
{
    private readonly IGenericRepository<User> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<UserService> _logger = logger;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    private readonly ITokenService _tokenService = tokenService;
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
        var exists = await repository
        .AnyAsync(x => x.Email == dto.Email);

        if (exists)
        {
            _logger.LogWarning("User with email {Email} already exists", dto.Email);
            throw new Exception("Email already exists.");
        }

        var user = _mapper.Map<User>(dto);
        user.CreatedAt = DateTime.UtcNow;
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.PasswordHash);

        await _repository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<UserAdminReadDto>(user);
    }
    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _repository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user == null)
            throw new Exception("Invalid credentials");

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            dto.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new Exception("Invalid credentials");

        return _tokenService.GenerateToken(user);
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
