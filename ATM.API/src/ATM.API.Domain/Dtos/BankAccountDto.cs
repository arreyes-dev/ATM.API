using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Domain.Entities
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
