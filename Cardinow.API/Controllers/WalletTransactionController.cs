using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cardinow.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class WalletTransactionController : ControllerBase
    {
        private readonly IWalletTransactionService _service;

        public WalletTransactionController(IWalletTransactionService service)
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
            var transactions = await _service.GetTransactionsByUserIdAsync(userId);
            return Ok(transactions);
        }
    }
}