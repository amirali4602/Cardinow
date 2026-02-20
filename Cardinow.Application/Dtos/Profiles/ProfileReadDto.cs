using Cardinow.Application.Dtos.Shared;

namespace Cardinow.Application.Dtos.Profiles;

public class ProfileReadDto : BaseEntityDto
{

    public Guid UserId { get; set; }
    public string? BannerUrl { get; set; }
    public string? LogoUrl { get; set; }
    public string? VcfLink { get; set; }

    // JSON (PostgreSQL jsonb)
    public string LinksJson { get; set; }
}