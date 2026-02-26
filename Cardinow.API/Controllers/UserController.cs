using Cardinow.Application.Dtos.Users;
using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cardinow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [Authorize(Roles = "Admin,RestrictedAdmin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }
    [Authorize(Roles = "Admin,RestrictedAdmin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUserRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (currentUserRole != "Admin" && currentUserId != id.ToString())
            return Forbid();
        var user = await _userService.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Create(RegisterUserDto dto)
    {
        var createdUser = await _userService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _userService.LoginAsync(dto);
        return Ok(new { token });
    }
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/role")]
    public async Task<IActionResult> UpdateRole(Guid id, UpdateUserRoleDto dto)
    {
        if(id != dto.Id) return BadRequest("ID in URL and body must match.");
        await _userService.UpdateRoleAsync(dto);
        return NoContent();
    }
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/block")]
    public async Task<IActionResult> BlockUser(Guid id, BlockUserDto dto)
    {
        if (id != dto.Id) return BadRequest("ID in URL and body must match.");
        await _userService.BlockUserAsync(dto);
        return NoContent();
    }
}