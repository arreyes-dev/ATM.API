using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Domain.Entities
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? DNI { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public List<BankAccountDto>? Accounts { get; set; }
    }
}
