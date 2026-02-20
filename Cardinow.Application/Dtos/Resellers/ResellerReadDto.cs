using Cardinow.Application.Dtos.Shared;

namespace Cardinow.Application.Dtos.Resellers;


public class ResellerReadDto : BaseEntityDto
{

    public Guid UserId { get; set; }

    public string? Domain { get; set; }

    public int? CommissionPercent { get; set; }

    // JSON For Renewal of Plan
    public string? RenewalPlansJson { get; set; }
}
