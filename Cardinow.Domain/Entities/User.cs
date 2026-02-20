using AutoMapper;
using Cardinow.Domain.Enums;
namespace Cardinow.Domain.Entities;
public class User : BaseEntity
{
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public UserRole Role { get; set; }
    public bool IsBlocked { get; set; } = false;
    // Relations
    public ICollection<Order> Orders { get; set; }
    public Wallet? Wallet { get; set; }
    public Profile? Profile { get; set; }
    public Reseller? Reseller { get; set; }
    public ICollection<Log> Logs { get; set; }
}
