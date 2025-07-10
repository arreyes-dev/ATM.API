using ATM.API.Application.Interfaces;
using ATM.API.Domain.ATM;
using ATM.API.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Application.Services
{
    public class OperationsService : IOperationsService
    {

        private readonly IOperationsRepository _operationsRepository;
        public OperationsService(IOperationsRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public async Task<ATMResponse > WithdrawCash(decimal amount) {
            return new ATMResponse()
            {
                Message = await _operationsRepository.GetCustomerData(1)
            }; 
        }

        public ATMResponse DepositCash(decimal amount) { 
            return new ATMResponse(); 
        }
    }
}
