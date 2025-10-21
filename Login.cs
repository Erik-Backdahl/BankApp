using System;
using System.Collections.Generic;


class Login
{
    public static void StartLogin()
    { Console.WriteLine("Enter your personal number:"); // Prompt user for personal number int personalNumber = int.Parse(Console.ReadLine()); // Read and parse input
        Console.WriteLine("Enter your password:"); // Prompt user for password
        string password = Console.ReadLine(); // Read input

        bool loggedIn = LoginUser(personalNumber, password); // Call login function

        if (loggedIn) // Check login result
        {
            Console.WriteLine("Login successful!"); // Success message
        }
        else 
        {
            Console.WriteLine("Login failed. Please try again."); // Failure message
        }
    }
    
    static bool LoginUser(int personalNumber, string password) // Function to validate login
    {
        foreach (var user in ) // Loop through users
        {
            if (user.PersonalNumber == personalNumber && user.Password == password) // Check credentials
            {
                return true; // Return true if match found
            }
        }
    }
}