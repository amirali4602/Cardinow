using Cardinow.Application.Dtos.Logs;
using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cardinow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogService _service;

        public LogController(ILogService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,RestrictedAdmin")]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _service.GetAllAsync();
            return Ok(logs);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LogReadDto dto)
        {
            await _service.AddLogAsync(dto);
            return Ok();
        }
    }
}