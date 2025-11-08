using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;
using BankApp.classes;
using BankApp.HelperClasses;


class Login
{
    public static async Task StartProgram()
    {
        DelayedTransaction.StartDelayedTransactions();
        while(true)
        {
            Console.WriteLine("press 1 to login");
            int userInput = GetUserInput.ValidateInt();
            switch(userInput)
            {
                case 1:
                    await StartLogin();
                    break;
                default:
                    return;
            }
        }
    }
    public static async Task StartLogin()
    {
        StartupAction.InitilizeTestData();
        int attempts = 0;
        int maxAttempts = 3;
        while (attempts < maxAttempts) // Loop until successful login
        {
            Console.WriteLine("Enter your personal number:"); // Prompt user for personal number
            int personalNumber = GetUserInput.ValidateInt(); // Read and parse input

            Console.WriteLine("Enter your password:"); // Prompt user for password
            string password = GetUserInput.ValidateString(); // Read input

            bool loggedIn = false; // Initialize login status
            var loggedInUser = default(User); // Track the logged-in user

            foreach (var user in Menu.AllUsers) // Iterate through all users
            {
                if (user.PersonalNumber == personalNumber && user.Password == password) // Check credentials
                {
                    loggedIn = true; // Set login status to true
                    loggedInUser = user; // Store the logged-in user
                    break; // Exit loop on successful login
                }
            }

            if (loggedIn && loggedInUser != null) // Check login result
            {
                Console.WriteLine("Login successful!"); // Success message
                await Menu.StartMenu(loggedInUser); // Pass the current user to StartMenu
                break;
            }
            else
            {
                Console.WriteLine("Login failed."); // Failure message
                attempts++;
            }

        }
        Console.WriteLine("You have been logged out");
    }
}