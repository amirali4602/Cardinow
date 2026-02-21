namespace Cardinow.Application.Dtos.Users;

public class RegisterUserDto
{
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
}
