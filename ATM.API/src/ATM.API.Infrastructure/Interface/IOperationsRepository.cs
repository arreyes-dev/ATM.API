using ATM.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Infrastructure.Interface
{
    public interface IOperationsRepository
    {
        Task<CustomerDto> GetCustomerData(int idCustomer);
        Task UpdateAccountBalance(int accountId, decimal newBalance);
    }
}
