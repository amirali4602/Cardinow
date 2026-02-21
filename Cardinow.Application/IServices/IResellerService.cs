using Cardinow.Application.Dtos.Resellers;

namespace Cardinow.Application.IServices;

public interface IResellerService
{
    Task<ResellerReadDto?> GetByUserIdAsync(Guid userId);
    Task UpdateDomainAsync(Guid id, string domain);
    Task UpdateCommissionAsync(Guid id, int? commissionPercent);
}
