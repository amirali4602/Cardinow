using Cardinow.Application.Dtos.Resellers;
using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cardinow.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ResellerController : ControllerBase
{
    private readonly IResellerService _service;

    public ResellerController(IResellerService service)
    {
        _service = service;
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
        var reseller = await _service.GetByUserIdAsync(userId);
        if (reseller == null) return NotFound();
        return Ok(reseller);
    }

    [HttpPut("{id}/domain")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateDomain(Guid id, [FromBody] UpdateResellerDomainDto dto)
    {
        await _service.UpdateDomainAsync(id, dto.Domain ?? string.Empty);
        return Ok();
    }

    [HttpPut("{id}/commission")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCommission(Guid id, [FromBody] UpdateCommissionDto dto)
    {
        await _service.UpdateCommissionAsync(id, dto.CommissionPercent);
        return Ok();
    }
}