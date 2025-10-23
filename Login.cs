using System;
using System.Collections.Generic;


class Login
{
    public static void StartLogin()
    {
        StartupAction.InitilizeTestData();
        while (true) // Loop until successful login
        {
            Console.WriteLine("Enter your personal number:"); // Prompt user for personal number
            int personalNumber = int.Parse(Console.ReadLine()); // Read and parse input

            Console.WriteLine("Enter your password:"); // Prompt user for password
            string password = Console.ReadLine(); // Read input

            bool loggedIn = false; // Initialize login status

            foreach (var user in Menu.AllUsers) // Iterate through all users
            {
                if (user.PersonalNumber == personalNumber && user.Password == password) // Check credentials
                {
                    loggedIn = true; // Set login status to true
                    break; // Exit loop on successful login
                }
            }

            if (loggedIn) // Check login result
            {
                Console.WriteLine("Login successful!"); // Success message
                Menu.StartMenu();
                break;
            }
            else
            {
                Console.WriteLine("Login failed. Please try again."); // Failure message
            }
        }
    }
}