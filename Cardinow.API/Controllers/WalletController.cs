using Cardinow.Application.Dtos.Wallets;
using Cardinow.Application.IServices;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Cardinow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletController : ControllerBase
{
    private readonly IWalletService _walletService;
    private readonly IValidator<CashoutRequestDto> _validator;

    public WalletController(IWalletService walletService, IValidator<CashoutRequestDto> validator)
    {
        _walletService = walletService;
        _validator = validator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var wallet = await _walletService.GetByUserIdAsync(userId);
        if (wallet == null) return NotFound();
        return Ok(wallet);
    }

    [HttpPost("{userId}/cashout")]
    public async Task<IActionResult> Cashout(Guid userId, [FromBody] CashoutRequestDto dto)
    {
        var validation = await _validator.ValidateAsync(dto);
        if (!validation.IsValid) return BadRequest(validation.Errors);

        var result = await _walletService.RequestCashoutAsync(userId, dto.Amount, dto.BankInfo);
        return Ok(result);
    }
}