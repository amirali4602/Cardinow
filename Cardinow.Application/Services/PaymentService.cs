using AutoMapper;
using Cardinow.Application.Dtos.Payment;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.Application.Services;
public class PaymentService : IPaymentService
{
    private readonly IGenericRepository<Payment> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaymentService(IGenericRepository<Payment> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PaymentReadDto>> GetAllAsync()
    {
        var payments = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PaymentReadDto>>(payments);
    }

    public async Task<PaymentReadDto?> GetByIdAsync(Guid id)
    {
        var payment = await _repository.GetByIdAsync(id);
        return payment == null ? null : _mapper.Map<PaymentReadDto>(payment);
    }

    public async Task CreateAsync(CreatePaymentDto dto)
    {
        var payment = _mapper.Map<Payment>(dto);
        payment.CreatedAt = DateTime.UtcNow;

        await _repository.AddAsync(payment);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task VerifyPaymentAsync(Guid id, bool isVerified)
    {
        var payment = await _repository.GetByIdAsync(id);
        if (payment == null) throw new Exception("Payment not found");

        payment.IsVerified = isVerified;
        payment.UpdatedAt = DateTime.UtcNow;

        _repository.Update(payment);
        await _unitOfWork.SaveChangesAsync();
    }
}