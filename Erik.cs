using System.Threading.Tasks;
using BankApp.classes;

class Erik
{
    public static async Task CreateNewAccount(User user)
    {
        bool validInput = false;
        int userIntInput = 0;
        while (!validInput)
        {
            Console.WriteLine("What kind of account would you like to create? (checking/savings)");
            Console.WriteLine("(1) For Checking account.\n (2) for Savings account");

            if (int.TryParse(Console.ReadLine(), out userIntInput) && userIntInput >= 1 && userIntInput <= 2)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("please enter a '1' or a '2'");
            }
        }

        string accountType;
        if (userIntInput == 1)
        {
            accountType = "Checking";
        }
        else
        {
            accountType = "Savings";
        }

        string selectedCurrency;
        
        validInput = false;
        while (!validInput)
        {
            Console.WriteLine("What currency should this account use?");
            Console.WriteLine("please enter the currency you want to use. \n EX: eu = Euro, sek = swedish crown, usd = US dollar");

            string? userStringInput = Console.ReadLine();


            if (userStringInput != null)
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync($"https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@2025.5.6/v1/currencies/{userStringInput}.json");

                if (response.IsSuccessStatusCode)
                {
                    selectedCurrency = userStringInput;
                }
            }
            else
            {
                Console.WriteLine("Currency not found. Please try again");
            }
        }

        user.Accounts.Add(new Account { AccountType = accountType, Currency = selectedCurrency });
    }
}