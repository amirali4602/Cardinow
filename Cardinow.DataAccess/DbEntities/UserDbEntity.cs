namespace Cardinow.DataAccess.DbEntities;

public class UserDbEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime LastLogin { get; set; } 
    public bool IsActive { get; set; }

}
