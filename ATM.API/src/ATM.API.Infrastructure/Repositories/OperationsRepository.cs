using ATM.API.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Infrastructure.Repositories
{
    public class OperationsRepository: IOperationsRepository
    {
        public string GetCustomerData(int idCustomer) {
            return "UserTest";
        }
    }
}
