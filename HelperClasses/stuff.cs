using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.HelperClasses
{


    public class Admin_user_add

    {

    }

    public class Admin_user
    {


        // method to add new admin user

        public static void AddAdminUser()
        {
            Console.WriteLine("Lägg till ny administratörsanvändare");
            Console.WriteLine(" Write Admin username:");
            string username = GetUserInput.ValidateString();
            Console.WriteLine("Write password:");
            string password = GetUserInput.ValidateString();
            Console.WriteLine("Write email:");
            Console.WriteLine("write personal number:");
            string personalnumber = GetUserInput.ValidateString();
            string email = GetUserInput.ValidateString();
            Console.WriteLine("Write role:");
            string role = GetUserInput.ValidateString();


            Menu.AllUsers.Add(new User { Name = username, Password = password, Email = "", PersonalNumber = 0, Administator = true });

            Console.WriteLine($"Ny administratörsanvändare '{username}' med rollen '{role}' har lagts till.");
        }


        // method to remove admin user
        public static void RemoveAdminUser()
        {
            Console.WriteLine("Write admin username you want to remove");
            string username = GetUserInput.ValidateString();

            var user = Menu.AllUsers.Find(u => u.Name == username && u.Administator);
            if (user != null)
            {
                Menu.AllUsers.Remove(user);
                Console.WriteLine($"Administratörsanvändare '{username} ' have been removed.");
            }
            else
            {
                Console.WriteLine($"Ingen administratörsanvändare med namnet '{username}' could be found.");
            }
        }
    }
}