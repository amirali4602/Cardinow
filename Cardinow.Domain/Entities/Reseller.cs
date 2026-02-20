namespace Cardinow.Domain.Entities;
public class Reseller : BaseEntity
{

    public Guid UserId { get; set; }
    public User User { get; set; }

    public string? Domain { get; set; }

    public string? AffiliateLink { get; set; }

    public int? CommissionPercent { get; set; }

    // JSON For Renewal of Plan
    public string? RenewalPlansJson { get; set; }
}