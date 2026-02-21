using Cardinow.Application.Dtos.Profiles;

namespace Cardinow.Application.IServices;

public interface IProfileService
{
    Task<ProfileReadDto?> GetByUserIdAsync(Guid userId);
    Task UpdateAsync(Guid userId, UpdateProfileDto dto);
}
