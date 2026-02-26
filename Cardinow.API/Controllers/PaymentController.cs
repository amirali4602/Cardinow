using Cardinow.Application.Dtos.Payment;
using Cardinow.Application.IServices;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cardinow.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _service;
    private readonly IValidator<CreatePaymentDto> _validator;

    public PaymentController(IPaymentService service, IValidator<CreatePaymentDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpPost]
    [Authorize(Roles = "Customer, Resellers")]
    public async Task<IActionResult> Create([FromBody] CreatePaymentDto dto)
    {
        var validation = await _validator.ValidateAsync(dto);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);

        await _service.CreateAsync(dto);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Customer")]
    public async Task<IActionResult> Get(Guid id)
    {
        var payment = await _service.GetByIdAsync(id);
        if (payment == null) return NotFound();
        return Ok(payment);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var payments = await _service.GetAllAsync();
        return Ok(payments);
    }
}