using Cardinow.Application.Dtos.Wallets;
using Cardinow.Application.IServices;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Claims;

namespace Cardinow.API.Controllers;

[Authorize]
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
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (currentUserId == null)
            return Unauthorized();

        if (role != "Admin" && currentUserId != userId.ToString())
            return Forbid();

        var wallet = await _walletService.GetByUserIdAsync(userId);
        if (wallet == null) return NotFound();

        return Ok(wallet);
    }

    [HttpPost("cashout")]
    public async Task<IActionResult> Cashout([FromBody] CashoutRequestDto dto)
    {
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return Unauthorized();

        var validation = await _validator.ValidateAsync(dto);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);
        var result = await _walletService.RequestCashoutAsync(
            Guid.Parse(currentUserId),
            dto
        );

        return Ok(result);
    }
}