using Cardinow.Domain.Entities;

namespace Cardinow.Domain.IRepositories;

public interface IPaymentRepository
    : IGenericRepository<Payment>
{
    Task<Payment?> GetByAuthorityAsync(string authority);
}
