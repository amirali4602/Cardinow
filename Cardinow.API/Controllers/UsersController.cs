using Microsoft.AspNetCore.Mvc;
using Cardinow.Application.Dtos;
using Cardinow.Application.IServices;
using Cardinow.DataAccess.DbEntities;
using Cardinow.Domain.DomainEntities;

namespace Cardinow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(
    IGenericService<UserDto, UserEntity, UserDbEntity,CreateUserDto,UpdateUserDto> genericService) : ControllerBase
{
    // GET: api/users
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var res = await genericService.GetAllAsync();
        return Ok(res);
    }

    // GET: api/users/guid
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var res = await genericService.GetByIdAsync(id);
        if (res == null)
            return NotFound();
        return Ok(res);
    }

    // POST: api/users
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto model)
    {
        await genericService.AddAsync(model);
        return Ok();
    }

    // PUT: api/users/guid
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserDto dto)
    {
        await genericService.UpdateAsync(dto);
        return NoContent();
    }

    // DELETE: api/users/guid
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await genericService.DeleteAsync(id);
        return NoContent();
    }
}


