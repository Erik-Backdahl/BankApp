using BankApp.HelperClasses;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace BankApp.classes
{
    public class Transaction
    {

    }

    public class Withdraw : Transaction
    {
        public required Account UserFromAccount { get; set; }
        public decimal RemoveAmmount { get; set; }
    }

    public class Deposit : Transaction
    {
        public required Account UserRecivingAccount { get; set; }
        public decimal AddAmmount { get; set; }
    }

    public class Transfer : Transaction
    {
        public required Account UserFromAccount { get; set; }
        public decimal RemoveAmmount { get; set; }
        public required Account UserRecivingAccount { get; set; }
        public decimal AddAmmount { get; set; }
    }
}