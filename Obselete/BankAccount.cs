using System;
using System.Reflection;
using BankApp.HelperClasses;

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
        Console.WriteLine("What account do you want to deposit to?"); // Prompt for 
        DisplayData.DisplayUserAccounts(currentUser); // Display user's accounts

        int accountNumber;

        while (true)
        {
            Console.WriteLine("Enter account by number:");
            accountNumber = GetUserInput.ValidateInt();

            if (accountNumber >= 0 && accountNumber < currentUser.Accounts.Count)
            {
                break; // Exit loop if valid account number is entered
            }
            else
            {
                Console.WriteLine("Invalid account number. Please try again."); // Prompt for valid input
            }
        }
        
        Console.WriteLine("How much do you want to deposit?"); // Prompt for deposit amou
        // nt
        decimal depositAmount = Convert.ToDecimal(GetUserInput.ValidateInt()); // Read deposit amount input

        currentUser.Accounts[accountNumber].Balance += depositAmount;

        Console.WriteLine("Deposit Sucessful!"); // Confirm successful deposit
    }
}
