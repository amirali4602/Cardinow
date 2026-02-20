
using Cardinow.Domain.Enums;

namespace Cardinow.Application.Dtos.Users;

public class UpdateUserRoleDto
{
    public Guid Id { get; set; }
    public UserRole Role { get; set; }
}