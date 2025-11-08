using System;
using System.Collections.Generic;
using BankApp.classes;

static class TakeLoan
{
    public static void Loan(Account account)
    {
        Console.WriteLine("=== Loan Application ===");

        Console.Write("Enter loan amount: ");
        decimal loanAmount = Convert.ToDecimal(Console.ReadLine());

         if (loanAmount <= 0)
        {
            Console.WriteLine("Loan amount must be greater than zero.");
            return;
        }

        Console.Write("Enter loan duration in years: ");
        int LoanInYears = Convert.ToInt32(Console.ReadLine());

        decimal interestRate = 0.05m; // 5% interest rate

        if (LoanInYears <= 0)
        {
            Console.WriteLine("Loan duration must be at least 1 year.");
            return;
        }

        account.Balance += loanAmount;

        decimal totalDebt = loanAmount * (1 + loanAmount * interestRate);

        Console.WriteLine($"\nYou have taken a loan of {loanAmount} SEK at {interestRate * 100}% interest.");
        Console.WriteLine($"You will need to repay {totalDebt} SEK after 1 year.");
        Console.WriteLine($"New account balance: {account.Balance} SEK");
    }
}