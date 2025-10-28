using System;

public class BankAccount // Class representing a bank account
{
    public string CustomerName { get; set; } // Property for customer's name
    public decimal Balance { get; private set; } // Property for account balance

    public BankAccount(string customerName, decimal initialBalance = 0) // Constructor with optional initial balance
    {
        CustomerName = customerName; // Set customer name
        Balance = initialBalance; // Set initial balance
    }

    public static void AskUserToDeposit(User currentUser)// Method to prompt user for deposit details
    {
        Console.WriteLine("What account do you want to deposit to?"); // Prompt for account type
        string accountType = Console.ReadLine(); // Read account type input

        Console.WriteLine("How much do you want to deposit?"); // Prompt for deposit amount
        if (decimal.TryParse(Console.ReadLine(), out decimal amount)) // Read and parse deposit amount
        {
            Deposit(amount); // Call deposit method
        }
        else
        {
            Console.WriteLine("Invalid amount entered. Please enter a valid number."); // Handle invalid input
        }
    }
}
