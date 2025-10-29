using System.ComponentModel;
using System.Threading.Tasks;
using BankApp.HelperClasses;
using BankApp.StaticClasses;
using StaticClasses.Endpoint;

class Menu
{
    public static List<User> AllUsers = [];
    public static async Task StartMenu(User currentUser)
    {
        Art.DisplayLogo();
        bool active = true;
        while (active)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayData.DisplayUserData(currentUser);

            Console.ForegroundColor = ConsoleColor.Cyan;
            DisplayData.DisplayMenu(currentUser.Administator);

            Console.ForegroundColor = ConsoleColor.Blue;

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    MenuOptions.Withdraw(currentUser);
                    break;
                case "2":
                    BankAccount.AskUserToDeposit(currentUser);
                    break;

                case "3":
                    await MenuOptions.CreateNewAccount(currentUser);
                    break;

                case "4":
                    DisplayData.DisplayUserAccounts(currentUser);
                    break;

                    case "5":
                       
                        Admin_user.AddAdminUser();
                        break;
                    case "6":
                        Admin_user.RemoveAdminUser();
                        break;

                    
                default:
                    active = false;
                    break;

            }
        }
        Console.WriteLine("Program ending");
    }
}