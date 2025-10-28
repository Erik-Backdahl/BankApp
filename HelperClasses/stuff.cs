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
            Console.WriteLine("Ange användarnamn:");
            string username = GetUserInput.ValidateString();
            Console.WriteLine("Ange lösenord:");
            string password = GetUserInput.ValidateString();

            Console.WriteLine(" ange rollen ");
            string role = GetUserInput.ValidateString();


            Menu.AllUsers.Add(new User { Name = username, Password = password, Email = "", PersonalNumber = 0, Administator = true });

            Console.WriteLine($"Ny administratörsanvändare '{username}' med rollen '{role}' har lagts till.");
        }


        // method to remove admin user
        public static void RemoveAdminUser()
        {
            Console.WriteLine("Ange användarnamn för administratörsanvändare som ska tas bort:");
            string username = GetUserInput.ValidateString();

            var user = Menu.AllUsers.Find(u => u.Name == username && u.Administator);
            if (user != null)
            {
                Menu.AllUsers.Remove(user);
                Console.WriteLine($"Administratörsanvändare '{username}' har tagits bort.");
            }
            else
            {
                Console.WriteLine($"Ingen administratörsanvändare med namnet '{username}' hittades.");
            }
        }
    }
}