using AutoMapper;
using Cardinow.Application.Dtos.Resellers;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.Application.Services;

public class ResellerService(IGenericRepository<Reseller> repository, IUnitOfWork unitOfWork, IMapper mapper) : IResellerService
{
    private readonly IGenericRepository<Reseller> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<ResellerReadDto?> GetByUserIdAsync(Guid userId)
    {
        var reseller = (await _repository.GetAllAsync())
            .FirstOrDefault(r => r.UserId == userId && !r.IsDeleted);

        return reseller == null ? null : _mapper.Map<ResellerReadDto>(reseller);
    }

    public async Task UpdateDomainAsync(Guid id, string domain)
    {
        var reseller = await _repository.GetByIdAsync(id) ?? throw new Exception("Reseller not found");
        reseller.Domain = domain;
        reseller.UpdatedAt = DateTime.UtcNow;

        _repository.Update(reseller);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateCommissionAsync(Guid id, int? commissionPercent)
    {
        var reseller = await _repository.GetByIdAsync(id) ?? throw new Exception("Reseller not found");
        reseller.CommissionPercent = commissionPercent;
        reseller.UpdatedAt = DateTime.UtcNow;

        _repository.Update(reseller);
        await _unitOfWork.SaveChangesAsync();
    }
}