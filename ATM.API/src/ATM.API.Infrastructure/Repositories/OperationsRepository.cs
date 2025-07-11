using ATM.API.Domain.Entities;
using ATM.API.Infrastructure.Contexts;
using ATM.API.Infrastructure.Entities;
using ATM.API.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Infrastructure.Repositories
{
    public class OperationsRepository: IOperationsRepository
    {

        private readonly BankingDbContext _bankingDbContext;


        public OperationsRepository(BankingDbContext bankingDbContext)
        {
            _bankingDbContext = bankingDbContext;
        }



        public async Task<CustomerDto?> GetCustomerData(int idCustomer)
        {
            var customer = await _bankingDbContext.Customers
                .Include(c => c.BankAccounts)
                .FirstOrDefaultAsync(c => c.Id == idCustomer);

            if (customer == null)
                return null;

            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                DNI = customer.DNI,
                Name = customer.Name,
                LastName = customer.LastName,
                Accounts = customer.BankAccounts?.Select(account => new BankAccountDto
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance
                }).ToList()
            };

            return customerDto;
        }

        public async Task UpdateAccountBalance(int accountId, decimal newBalance)
        {
            var account = await _bankingDbContext.BankAccounts.FirstOrDefaultAsync(a => a.Id == accountId);

            if (account != null)
            {
                account.Balance = newBalance;
                await _bankingDbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró la cuenta con ID {accountId}.");
            }
        }

    }
}
