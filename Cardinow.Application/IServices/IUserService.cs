using Cardinow.Application.Dtos.Users;

namespace Cardinow.Application.IServices;

public interface IUserService
{
    Task<UserAdminReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<UserAdminReadDto>> GetAllAsync();
    Task<UserAdminReadDto> CreateAsync(RegisterUserDto dto);
    Task VerifyCodeAsync(VerifyCodeDto dto);
    Task UpdateRoleAsync(UpdateUserRoleDto dto);
    Task BlockUserAsync(BlockUserDto dto);
}