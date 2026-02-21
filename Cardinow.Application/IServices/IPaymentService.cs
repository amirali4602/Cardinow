using Cardinow.Application.Dtos.Payment;

namespace Cardinow.Application.IServices;

public interface IPaymentService
{
    Task<PaymentReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<PaymentReadDto>> GetAllAsync();
    Task CreateAsync(CreatePaymentDto dto);
    Task VerifyPaymentAsync(Guid id, bool isVerified);
}
