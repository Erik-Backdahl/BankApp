using System;
using System.Collections.Generic;


class Login
{
    public static void StartLogin(Func<int, string, bool> LoginFunction)
    {
        Console.WriteLine("Enter your personal number:"); // Prompt user for personal number
        int personalNumber = int.Parse(Console.ReadLine()); // Read and parse input

        Console.WriteLine("Enter your password:"); // Prompt user for password
        string password = Console.ReadLine(); // Read input

        bool loggedIn = LoginFunction(personalNumber, password); // Attempt login

        if (loggedIn) // Check login result
        {
            Console.WriteLine("Login successful!"); // Success message
        }
        else
        {
            Console.WriteLine("Login failed. Please try again."); // Failure message
        }
    }
}