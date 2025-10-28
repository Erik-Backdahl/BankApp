using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using BankApp.classes;

static class Interest
{
    public static decimal interestRate = 0.02m; // 2% yearly interest

    public static void ShowYearlyInterest(Account account) // returns the yearly interest for a given account
    {
        decimal yearlyInterest = account.Balance * interestRate; // Simple interest calculation
        Console.WriteLine($"Yearly interest for account with balance {account.Balance} with 2% interest rate is {yearlyInterest} {account.Currency}");

    }

}
