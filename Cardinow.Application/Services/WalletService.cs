using AutoMapper;
using Cardinow.Application.Dtos.Wallets;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.Application.Services;

public class WalletService : IWalletService
{
    private readonly IGenericRepository<Wallet> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WalletService(IGenericRepository<Wallet> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<WalletReadDto?> GetByUserIdAsync(Guid userId)
    {
        var wallet = (await _repository.GetAllAsync()).FirstOrDefault(w => w.UserId == userId && !w.IsDeleted);
        return wallet == null ? null : _mapper.Map<WalletReadDto>(wallet);
    }

    public async Task<CashoutRequestDto> RequestCashoutAsync(Guid userId, CashoutRequestDto dto)
    {
        var wallet = (await _repository.GetAllAsync()).FirstOrDefault(w => w.UserId == userId && !w.IsDeleted);
        if (wallet == null) throw new Exception("Wallet not found");
        if (dto.Amount <= 0 || dto.Amount > wallet.Balance) throw new Exception("Invalid amount");

        wallet.Balance -= dto.Amount;
        wallet.CashedOut += dto.Amount;
        wallet.UpdatedAt = DateTime.UtcNow;

        _repository.Update(wallet);
        await _unitOfWork.SaveChangesAsync();

        return new CashoutRequestDto { Amount = dto.Amount, BankInfo = dto.BankInfo };
    }
}