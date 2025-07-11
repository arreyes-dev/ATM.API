using ATM.API.Application.Interfaces;
using ATM.API.Domain.ATM;
using Microsoft.AspNetCore.Mvc;

namespace ATM.API.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ATMController : ControllerBase
    {
        private readonly ILogger<ATMController> _logger;
        private readonly IOperationsService _operationsService;

        public ATMController(ILogger<ATMController> logger, IOperationsService operationsService)
        {
            _logger = logger;
            _operationsService = operationsService ?? throw new ArgumentNullException(nameof(operationsService));
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> WithdrawCash(decimal amount, int idCustomer)
        {
            var result = await _operationsService.WithdrawCash(amount, idCustomer);
            return Ok(result);
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult > DepositCash(decimal amount, int idCustomer)
        {
            var result = await _operationsService.DepositCash(amount, idCustomer);
            return Ok(result);
        }
    }



}
