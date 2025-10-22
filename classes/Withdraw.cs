using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.classes
{
    internal class muhammad
    {
        public static void Withdraw(User currentUser)
        {
            Console.WriteLine("\nEnter your account number:");
            int index = 0;
            foreach (var account in currentUser.Accounts)
            {
                Console.WriteLine($"({index}) " + account.AccountNumber);
                index++;
            }

        }
    }
}
