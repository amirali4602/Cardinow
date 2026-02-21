using Cardinow.Application.Dtos.Users;
using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Cardinow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Create(RegisterUserDto dto)
    {
        var createdUser = await _userService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id}/role")]
    public async Task<IActionResult> UpdateRole(Guid id, UpdateUserRoleDto dto)
    {
        if(id != dto.Id) return BadRequest("ID in URL and body must match.");
        await _userService.UpdateRoleAsync(dto);
        return NoContent();
    }

    [HttpPut("{id}/block")]
    public async Task<IActionResult> BlockUser(Guid id, BlockUserDto dto)
    {
        if (id != dto.Id) return BadRequest("ID in URL and body must match.");
        await _userService.BlockUserAsync(dto);
        return NoContent();
    }
}