using ATM.API.Application.Interfaces;
using ATM.API.Domain.ATM;
using ATM.API.Domain.Entities;
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

        public async Task<ATMResponse> WithdrawCash(decimal amount, int idCustomer)
        {
            if (amount > 1000)
            {
                return new ATMResponse
                {
                    Success = false,
                    Message = "No se puede retirar más de 1000 EUR por operación."
                };
            }
            var customerData = await _operationsRepository.GetCustomerData(idCustomer);
            if (customerData == null || customerData.Accounts == null || !customerData.Accounts.Any())
            {
                return new ATMResponse
                {
                    Success = false,
                    Message = "Cliente o cuenta no encontrada."
                };
            }
            var account = customerData.Accounts.First();
            if (amount > account.Balance)
            {
                return new ATMResponse
                {
                    Success = false,
                    Message = "Fondos insuficientes.",
                    Balance = account.Balance
                };
            }
            account.Balance -= amount;
            await _operationsRepository.UpdateAccountBalance(account.Id, account.Balance); 
            return new ATMResponse
            {
                Success = true,
                Message = "Retiro exitoso.",
                Balance = account.Balance
            };
        }


        public async Task<ATMResponse> DepositCash(decimal amount, int idCustomer)
        {
            if (amount > 3000)
            {
                return new ATMResponse
                {
                    Success = false,
                    Message = "No se puede ingresar más de 3000 EUR por operación."
                };
            }
            var customerData = await _operationsRepository.GetCustomerData(idCustomer);
            if (customerData == null || customerData.Accounts == null || !customerData.Accounts.Any())
            {
                return new ATMResponse
                {
                    Success = false,
                    Message = "Cliente o cuenta no encontrada."
                };
            }
            var account = customerData.Accounts.First();
            account.Balance += amount;
            await _operationsRepository.UpdateAccountBalance(account.Id, account.Balance);
            return new ATMResponse
            {
                Success = true,
                Message = "Ingreso exitoso.",
                Balance = account.Balance
            };
        }

    }
}
