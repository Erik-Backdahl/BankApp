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
        public string AccountNumber { get; set; } =Guid.NewGuid().ToString();
        public string ownerid { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public string Currency { get; set; }

        



       
        



        


        //method to crate a new account
        public void  CreateAccount()
        {
            
            var account = new Account();
            account.AccountNumber = Guid.NewGuid().ToString();
            account.Balance = 0;
            Console.WriteLine("Enter account type (Savings/Checking): ");
            account.AccountType = Console.ReadLine();
            Console.WriteLine("Enter currency (e.g. SEK, USD): ");
            account.Currency = Console.ReadLine();

            accounts.Add(account);
            Console.WriteLine($"Account created successfully! Account Number: {account.AccountNumber}" + $" Balance: {account.Balance}" + $" Type: {account.AccountType}" + $" Currency: {account.Currency}");


        }




    }
}
