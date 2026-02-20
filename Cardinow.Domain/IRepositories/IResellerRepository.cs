using Cardinow.Domain.Entities;

namespace Cardinow.Domain.IRepositories;

public interface IResellerRepository
    : IGenericRepository<Reseller>
{
    Task<Reseller?> GetByDomainAsync(string domain);
}
