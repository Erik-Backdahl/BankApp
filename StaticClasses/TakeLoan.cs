using System;
using BankApp.classes;

static class TakeLoan
{
    public static void Loan(Account account)
    {
        Console.WriteLine("=== Loan Application ===");

        decimal loanAmount;
        while (true)
        {
            Console.Write("Enter loan amount: ");
            if (decimal.TryParse(Console.ReadLine(), out loanAmount))
            {
                if (loanAmount > 0)
                    break;
                else
                    Console.WriteLine("Loan amount must be greater than zero.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        int LoanInYears;
        while (true)
        {
            Console.Write("Enter loan duration in years: ");
            if (int.TryParse(Console.ReadLine(), out LoanInYears))
            {
                if (LoanInYears > 0)
                    break;
                else
                    Console.WriteLine("Loan duration must be at least 1 year.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }

        decimal interestRate = 0.05m; // 5% interest rate

        account.Balance += loanAmount;

        decimal totalDebt = loanAmount * (1 + interestRate * LoanInYears);

        Console.WriteLine($"\nYou have taken a loan of {loanAmount} SEK at {interestRate * 100}% interest per year.");
        Console.WriteLine($"You will need to repay {totalDebt} SEK after {LoanInYears} year(s).");
        Console.WriteLine($"New account balance: {account.Balance} SEK");
    }
}