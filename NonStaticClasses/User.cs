

using BankApp.classes;
using BankApp.HelperClasses;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class User
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required int PersonalNumber { get; set; }
    public bool Administator { get; set; } = false;
    public List<Account> Accounts { get; set; } = [];
    public decimal TotalBalance
    {
        get
        {
            decimal balance = 0;
            foreach (Account account in Accounts)
            {
                balance += account.Balance;
            }
            return balance;
        }
    }
}