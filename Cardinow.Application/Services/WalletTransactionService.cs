using AutoMapper;
using Cardinow.Application.Dtos.Wallets;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.Application.Services;

public class WalletTransactionService : IWalletTransactionService
{
    private readonly IGenericRepository<WalletTransaction> _repository;
    private readonly IGenericRepository<Wallet> _walletRepo;
    private readonly IMapper _mapper;

    public WalletTransactionService(
        IGenericRepository<WalletTransaction> repository,
        IGenericRepository<Wallet> walletRepo,
        IMapper mapper)
    {
        _repository = repository;
        _walletRepo = walletRepo;
        _mapper = mapper;
    }

    public async Task<WalletTransactionsListDto> GetTransactionsByUserIdAsync(Guid userId)
    {
        var wallet = (await _walletRepo.GetAllAsync()).FirstOrDefault(w => w.UserId == userId && !w.IsDeleted);
        if (wallet == null) throw new Exception("Wallet not found");

        var transactions = (await _repository.GetAllAsync())
            .Where(t => t.WalletId == wallet.Id && !t.IsDeleted)
            .ToList();

        return new WalletTransactionsListDto
        {
            Balance = wallet.Balance,
            Transactions = _mapper.Map<ICollection<WalletTransactionDto>>(transactions)
        };
    }
}