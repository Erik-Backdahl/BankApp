using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.classes
{
    public class Account
    {
        public required int OwnerPersonNumber { get; set; } 
        public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
        public decimal Balance { get; set; }
        public required string AccountType { get; set; }
        public required string Currency { get; set; }
    }
}
