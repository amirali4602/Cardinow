using Cardinow.Domain.Enums;

namespace Cardinow.Domain.Entities;
public class Log : BaseEntity
{
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public LogAction Action { get; set; }

    public string? Details { get; set; }

    public string? IpAddress { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}