using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Cardinow.DataAccess.Repositories;
public class PaymentRepository
    : GenericRepository<Payment>, IPaymentRepository
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Payment?> GetByAuthorityAsync(string authority)
    {
        return await _context.Payments
            .FirstOrDefaultAsync(x => x.Authority == authority);
    }
}