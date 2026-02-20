namespace Cardinow.Domain.Entities;
public class Profile : BaseEntity
{

    public Guid UserId { get; set; }
    public User User { get; set; }
    public string? BannerUrl { get; set; }
    public string? LogoUrl { get; set; }
    public string? VcfLink { get; set; }

    // JSON (PostgreSQL jsonb)
    public string LinksJson { get; set; }
}