using System.Security.Principal;
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
                    if (account.AccountType == "Savings")
                    {
                        Interest.ShowYearlyInterest(account);
                    }

                }
            }
        }
        public static void DisplayUserAccounts(User user)
        {
            int index = 0;
            foreach (Account account in user.Accounts)
            {
                Console.WriteLine($"({index}) Type: {account.AccountType} current balance: {account.Balance} {account.Currency}");
                index++;
            }
        }
        public static void DisplayMenu(bool Administator)
        {
            if (Administator)
            {
                Console.WriteLine(
                $"(1) Withdraw\n" +
                "(2) Deposit\n" +
                "(3) Open a new Account\n" +
                "(4) to take out a Loan\n" +
                "(5) Display all user accounts\n" +
                "(6) Display all user info\n" +
                "(7) Change Your user info\n" +
                "(8) Create new Admin user\n" +
                "(9) Remove Admin user\n" +
                "anything else: Exit");

            }
            else
            {
                Console.WriteLine(
                $"(1) Withdraw\n" +
                "(2) Deposit\n" +
                "(3) Open a new Account\n" +
                "(4) to take out a Loan\n" +
                "(5) Display all user accounts\n" +
                "(6) Display all user info\n" +
                "(7) Change Your user info\n" +
                "anything else: Exit"
                    );
            }

        }


    }
}