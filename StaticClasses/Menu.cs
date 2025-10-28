using System.ComponentModel;
using System.Threading.Tasks;
using BankApp.HelperClasses;
using StaticClasses.Endpoint;

class Menu
{
    public static List<User> AllUsers = [];
    public static async Task StartMenu(User currentUser)
    {
        bool active = true;
        while (active)
        {
            DisplayData.DisplayUserData(currentUser);

            DisplayData.DisplayMenu(User.Administator);

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

                default:
                    active = false;
                    break;

            }
        }
        Console.WriteLine("Program ending");
    }
}