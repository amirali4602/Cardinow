using Cardinow.Application.Dtos.Orders;
using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cardinow.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,RestrictedAdmin")]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
            return NotFound();

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (currentUserId == null)
            return Unauthorized();

        if (role != "Admin" && order.UserId.ToString() != currentUserId)
            return Forbid();

        return Ok(order);
    }

    [HttpPost]
    [Authorize(Roles = "Customer, DedicatedReseller, AffiliateReseller")]

    public async Task<IActionResult> Create(CreateOrderDto dto)
    {
        var created = _orderService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}/status")]
    [Authorize(Roles = "Admin, RestrictedAdmin")]
    public async Task<IActionResult> UpdateStatus(Guid id, UpdateOrderStatusDto dto)
    {
        await _orderService.UpdateStatusAsync(id, dto.Status);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _orderService.SoftDeleteAsync(id);
        return NoContent();
    }
}