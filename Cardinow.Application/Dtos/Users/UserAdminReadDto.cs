using AutoMapper;
using Cardinow.Application.Dtos.Shared;
using Cardinow.Domain.Enums;
namespace Cardinow.Application.Dtos.Users;
public class UserAdminReadDto : BaseEntityDto
{
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public UserRole Role { get; set; }
    public bool IsBlocked { get; set; } = false;
}
