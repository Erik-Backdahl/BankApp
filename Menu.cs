using System.ComponentModel;

class Menu
{
    public static List<User> AllUsers = [];
    public static void StartMenu()
    {
        bool active = true;
        while (active)
        {

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    //INSERT WITHDRAW METHOD HERE
                    break;
                case "2":
                    //INSERT DEPOSIT METHOD HERE
                    break;

                case "3":
                    //INSERT CREATE NEW ACCOUNT HERE
                    break;

                case "4":
                    //
                    break;

                default:
                    break;

            }
        }
    }
}