using ATM.API.Domain.ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Application.Interfaces
{
    public interface IOperationsService
    {

        public Task<ATMResponse> WithdrawCash(decimal amount);
        public ATMResponse DepositCash(decimal amount);
    }
}
