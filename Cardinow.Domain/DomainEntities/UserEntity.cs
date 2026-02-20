namespace Cardinow.Domain.DomainEntities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime LastLogin { get; set; }
    public bool IsActive { get; set; }
}
