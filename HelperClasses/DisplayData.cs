using BankApp.classes;

namespace BankApp.HelperClasses
{
    class DisplayData
    {
        public static void DisplayUserData(User user)
        {
            Console.WriteLine($"Welcome {user.Name}");
            Console.WriteLine($"Total balance in all accounts: {user.TotalBalance}");
            if (user.Accounts.Count == 0)
            {
                Console.WriteLine($"You currently have no active accounts please navigate the menu to add an account\n");
            }
            else
            {
                Console.WriteLine($"You have {user.Accounts.Count} active accounts:");
                foreach (Account account in user.Accounts)
                {
                    Console.WriteLine($"{account.AccountType}\t {account.Balance} {account.Currency}");

                }
            }
        }
        public static void DisplayMenu(Boolean Administator)
        {
            if (Administator)
            {
                Console.WriteLine($"(1) Withdraw\n(2) Deposit\n(3) Open a new Account\n(4) to take out a Loan\n(9) Exit");
            }
            else
            {
                Console.WriteLine($"(1) Withdraw\n(2) Deposit\n(3) Open a new Account\n(4) to take out a Loan\n(5) INSERT COOL ADMIN OPTIONS HERE\n(9) Exit");
            }
            
        }
    }
}