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

        public ATMController(ILogger<ATMController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Withdraw")]
        public  ATMResponse WithdrawCash(decimal amount)
        {
            return _operationsService.WithdrawCash(amount);
        }

        [HttpPost("Deposit")]
        public ATMResponse DepositCash(decimal amount)
        {
            return _operationsService.DepositCash(amount); 
        }
    }



}
