using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Domain.Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public int Balance { get; set; }
    }
}
