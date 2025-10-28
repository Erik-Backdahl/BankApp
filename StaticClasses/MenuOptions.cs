using BankApp.classes;

namespace StaticClasses.Endpoint
{
    class MenuOptions
    {
        public static void Withdraw(User currentUser)
        {//Skapad av Muhammad
            Console.WriteLine("\nEnter your account number:");
            int index = 0;
            foreach (var account in currentUser.Accounts)
            {
                Console.WriteLine($"({index}) " + account.AccountNumber);
                index++;
            }
            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid number");
                }
            }
            var selectedAccount = currentUser.Accounts[number];

            Console.Write("Ange belopp att ta ut: ");
            decimal amount;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ange ett giltigt belopp större än 0.");
                }
            }
            Account newAccount = new Account();

            if (selectedAccount.Balance >= amount)
            {

                Console.WriteLine($"\nUttag på {amount} {selectedAccount.Currency} har registrerats.");


                Console.WriteLine("Transaktionen kommer behandlas inom 15 minuter.");
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo för detta uttag.");
            }

        }
        public static async Task CreateNewAccount(User user)
        {//Skapad av Erik
            bool validInput = false;
            int userIntInput = 0;
            while (!validInput)
            {
                Console.WriteLine("What kind of account would you like to create? (checking/savings)");
                Console.WriteLine("(1) For Checking account.\n(2) for Savings account");

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
            Console.WriteLine($"Sucess you have selected \"{accountType}\" \n");

            string selectedCurrency = "";

            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("What currency should this account use?");
                Console.WriteLine("please enter the currency you want to use. \nEX: eu = Euro, sek = swedish crown, usd = US dollar");

                string? userStringInput = Console.ReadLine();

                if (userStringInput != null)
                {

                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync($"https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@2025.5.6/v1/currencies/{userStringInput}.json");

                    if (response.IsSuccessStatusCode)
                    {
                        selectedCurrency = userStringInput;
                        validInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Currency not found. Please try again");
                }
            }

            user.Accounts.Add(new Account { AccountType = accountType, Currency = selectedCurrency });
            Console.WriteLine($"Success. Created a {accountType} account with the currency {selectedCurrency}");

            return;
        }
    }
}