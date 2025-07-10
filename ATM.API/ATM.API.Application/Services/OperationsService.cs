using ATM.API.Application.Interfaces;
using ATM.API.Domain.ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Application.Services
{
    public class OperationsService : IOperationsService
    {
        public ATMResponse WithdrawCash(decimal amount) {
            return new ATMResponse(); 
        }

        public ATMResponse DepositCash(decimal amount) { 
            return new ATMResponse(); 
        }
    }
}
