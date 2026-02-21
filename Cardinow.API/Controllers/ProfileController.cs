using Cardinow.Application.Dtos.Profiles;
using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Cardinow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController(IProfileService profileService) : ControllerBase
{
    private readonly IProfileService _profileService = profileService;

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var profile = await _profileService.GetByUserIdAsync(userId);
        if (profile == null) return NotFound();
        return Ok(profile);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> Update(Guid userId, UpdateProfileDto dto)
    {
        await _profileService.UpdateAsync(userId, dto);
        return NoContent();
    }
}