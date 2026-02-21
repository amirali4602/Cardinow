using Cardinow.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Cardinow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var transactions = await _service.GetTransactionsByUserIdAsync(userId);
            return Ok(transactions);
        }
    }
}