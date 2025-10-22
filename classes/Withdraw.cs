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
            int number;
while (true)
{
    if(int.TryParse(Console.ReadLine(), out number))
    {
        break;
    }
    else
    {
        Console.WriteLine("Enter a valid number");
    }
}
var selectedAccount = currentUser.Accounts[number];

Console.Write("Ange belopp att ta ut: ");
decimal amount;
while (true)
{
    if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
    {
        break;
    }
    else
    {
        Console.WriteLine("Ange ett giltigt belopp större än 0.");
    }
}

if (selectedAccount.Balance >= amount)
{
    
    Console.WriteLine($"\nUttag på {amount} {selectedAccount.Currency} har registrerats.");


    Console.WriteLine("Transaktionen kommer behandlas inom 15 minuter.");
}
else
{
    Console.WriteLine("Otillräckligt saldo för detta uttag.");
}

        }
    }
}
