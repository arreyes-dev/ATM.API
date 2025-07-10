using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Domain.ATM
{
    public class ATMResponse
    {
        public string? Status {get;set;}
        public string? Message {get;set;}
        public string? Balance { get;set;}
    }
}
