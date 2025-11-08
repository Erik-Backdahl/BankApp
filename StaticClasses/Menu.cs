using System.ComponentModel;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BankApp.HelperClasses;
using BankApp.StaticClasses;
using StaticClasses.Endpoint;

class Menu
{
    public static List<User> AllUsers = new List<User>();
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

            string userInput = GetUserInput.ValidateString();
            switch (userInput)
            {
                case "1":
                    MenuOptions.Withdraw(currentUser);
                    break;
                case "2":
                    MenuOptions.Deposit(currentUser);
                    break;

                case "3":
                    await MenuOptions.CreateNewAccount(currentUser);
                    break;

                case "4":
                    TakeLoan.Loan(currentUser.Accounts[0]); // flytta denna metod fron TakeLoan.cs till MenuOptions.cs när den är klar
                    break;

                case "5":
                    await Transfer.TransferFunds(currentUser);
                    break;

                case "6":
                    DisplayData.DisplayUserAccounts(currentUser);
                    break;

                case "7":
                    MenuOptions.DisplayUserData(currentUser);
                    break;

                case "8":
                    MenuOptions.UpdateUserData(currentUser);
                    break;


                case "9":
                    if (currentUser.Administator)
                        Admin_user.AddAdminUser();
                    break;

                case "10":
                    if (currentUser.Administator)
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