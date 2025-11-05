using System;
using System.Collections.Generic;
using System.Diagnostics;


class Login
{
    public static async Task StartLogin()
    {
        StartupAction.InitilizeTestData();
        int attempts = 0;
        int maxAttempts = 3;
        while (attempts < maxAttempts) // Loop until successful login
        {
            Console.WriteLine("Enter your personal number:"); // Prompt user for personal number
            int personalNumber = int.Parse(Console.ReadLine()); // Read and parse input

            Console.WriteLine("Enter your password:"); // Prompt user for password
            string password = Console.ReadLine(); // Read input

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
        Console.WriteLine("Login closed you failed 3 times.");
    }
}