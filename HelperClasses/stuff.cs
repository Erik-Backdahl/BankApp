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
            string email = GetUserInput.ValidateString();
            Console.WriteLine("write personal number:");
            int personalnumber = GetUserInput.ValidateInt();
            Console.WriteLine("Write role:");
            string role = GetUserInput.ValidateString();


            Menu.AllUsers.Add(new User { Name = username, Password = password, Email = email, PersonalNumber = personalnumber, Administator = true });

            Console.WriteLine($"New Admin '{username}' with  roll '{role}' have been added.");
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
                Console.WriteLine($"Admin '{username} ' have been removed.");
            }
            else
            {
                Console.WriteLine($"No admin with the name '{username}' could be found.");
            }
        }
    }
}