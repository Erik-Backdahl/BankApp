

using BankApp.classes;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class User
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required int PersonalNumber { get; set; }
    public bool Administator { get; set; } = false;
    public List<Account> Accounts { get; set; } = [];
    public decimal TotalBalance
    {
        get
        {
            decimal balance = 0;
            foreach (Account account in Accounts)
            {
                balance += account.Balance;
            }
            return balance;
        }
    }




    // Method to show CurrentUser Information 
    public static void DisplayUserData(User currentUser)
    {
        string name = currentUser.Name;
        string email = currentUser.Email;
        string password = currentUser.Password;
        Console.WriteLine($"Name {name}");
        Console.WriteLine($"Email{email}");

        Console.WriteLine($"Password {password}");










    }



    public static void UpdateUserData(User currentUser)// UpdateUser
    {

        Console.WriteLine("\n=== Update customer information ===");
        Console.WriteLine("1. Change name");
        Console.WriteLine("2. Change email");
        Console.WriteLine("3. Change Password");
        Console.WriteLine("0. Loging ");
      


        string choice = Console.ReadLine();

        switch (choice)
        {

            case "1":
                string newname = Console.ReadLine();
                newname = currentUser.Name;
                break;
                Console.WriteLine("Your name have been changed " + newname);

            case "2":
                Console.WriteLine( "Write ur new Email" );
                string newemail = Console.ReadLine();
                newemail = currentUser.Email;
               
                Console.WriteLine("Your Email have been changed" + newemail);
                break;
            case "3":
                string newpassword = Console.ReadLine();
                newpassword = currentUser.Password;
                Console.WriteLine( "Your New Password " + newpassword);
                break;
               
                case "0":

                Login.StartLogin();
                break;
            default:
                Console.WriteLine("\"❌ Invalid selection, please try again\".\n");
                break;





        }


    }
}



    

   


               


   
   

  


    








  













    
        
        
       


        
        
        
        
        
        
        
       






    







