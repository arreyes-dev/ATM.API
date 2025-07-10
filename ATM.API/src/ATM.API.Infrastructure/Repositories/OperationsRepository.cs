using ATM.API.Infrastructure.Contexts;
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


        public async Task<string> GetCustomerData(int idCustomer) {

            var customer = await _bankingDbContext.Customers
                  .Include(c => c.BankAccounts)
                  .FirstOrDefaultAsync(c => c.Id == idCustomer);

            if (customer == null)
            {
                return "";
            }

            return "UserTest";
        }
    }
}
