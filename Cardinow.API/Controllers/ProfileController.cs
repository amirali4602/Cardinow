using Cardinow.Application.Dtos.Profiles;
using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cardinow.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfilesController(IProfileService profileService) : ControllerBase
{
    private readonly IProfileService _profileService = profileService;

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (currentUserId == null)
            return Unauthorized();

        if (role != "Admin" && currentUserId != userId.ToString())
            return Forbid();
        var profile = await _profileService.GetByUserIdAsync(userId);
        if (profile == null) return NotFound();
        return Ok(profile);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> Update(Guid userId, UpdateProfileDto dto)
    {
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (currentUserId == null)
            return Unauthorized();

        if (role != "Admin" && currentUserId != userId.ToString())
            return Forbid();
        await _profileService.UpdateAsync(userId, dto);
        return NoContent();
    }
}