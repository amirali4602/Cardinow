namespace Cardinow.Application.Dtos;
public class UserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime LastLogin { get; set; } 
    public bool IsActive { get; set; } 
   
}
public class CreateUserDto
{
    public string FullName { get; set; } = null!;
    public DateTime LastLogin { get; set; }
    public bool IsActive { get; set; }
}
public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime LastLogin { get; set; }
    public bool IsActive { get; set; }
}