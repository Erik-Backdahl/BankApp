using BankApp.classes;
using BankApp.HelperClasses;

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
                Console.WriteLine($"({index}) " + account.Balance + " " + account.Currency);
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


            Console.Write("Ange belopp att ta ut: ");
            decimal amount;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0 && amount <= currentUser.Accounts[number].Balance)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ange ett giltigt belopp större än 0.");
                }
            }


            Console.WriteLine($"\nWithdrawl of {amount} {currentUser.Accounts[number].Currency} has been scheduled");
            DelayedTransaction.FormatAndAddWithdraw(currentUser.Accounts[number], amount);

        }
        public static void Deposit(User currentUser)// Method to prompt user for deposit details
        {//skapad av Mustafa
            Console.WriteLine("What account do you want to deposit to?"); // Prompt for 
            DisplayData.DisplayUserAccounts(currentUser); // Display user's accounts

            int accountNumber;

            while (true)
            {
                Console.WriteLine("Enter account by number:");
                accountNumber = GetUserInput.ValidateInt();

                if (accountNumber >= 0 && accountNumber < currentUser.Accounts.Count)
                {
                    break; // Exit loop if valid account number is entered
                }
                else
                {
                    Console.WriteLine("Invalid account number. Please try again."); // Prompt for valid input
                }
            }

            Console.WriteLine("How much do you want to deposit?"); // Prompt for deposit amou
                                                                   // nt
            decimal depositamount = Convert.ToDecimal(GetUserInput.ValidateInt()); // Read deposit amount input

            DelayedTransaction.FormatAndAddDeposit(currentUser.Accounts[accountNumber], depositamount);

            Console.WriteLine("Deposit Sucessful!"); // Confirm successful deposit
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

            user.Accounts.Add(new Account { OwnerPersonNumber = user.PersonalNumber, AccountType = accountType, Currency = selectedCurrency });
            Console.WriteLine($"Success. Created a {accountType} account with the currency {selectedCurrency}");

            return;
        }
        public static void DisplayUserData(User currentUser)
        {//skapad av Siem
            Console.WriteLine($"Name {currentUser.Name}");
            Console.WriteLine($"Email {currentUser.Email}");
            Console.WriteLine($"Password {currentUser.Password}");
        }
        public static void UpdateUserData(User currentUser)// UpdateUser
        {//skapad av Siem
            while (true)
            {
                Console.WriteLine("\n=== Update customer information ===");
                Console.WriteLine("1. Change name");
                Console.WriteLine("2. Change email");
                Console.WriteLine("3. Change Password");
                Console.WriteLine("0. Finish update");
                string choice = GetUserInput.ValidateString();

                switch (choice)
                {

                    case "1":
                        string newname = GetUserInput.ValidateString();
                        currentUser.Name = newname;
                        Console.WriteLine("Your name have been changed " + newname);
                        break;

                    case "2":
                        Console.WriteLine("Write ur new Email");
                        string newemail = GetUserInput.ValidateString();
                        currentUser.Email = newemail;
                        Console.WriteLine("Your Email have been changed" + newemail);
                        break;
                    case "3":
                        string newpassword = GetUserInput.ValidateString();
                        currentUser.Password = newpassword;
                        Console.WriteLine("Your password have been changed" + newpassword);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("\"❌ Invalid selection, please try again\".\n");
                        break;

                }
            }
        }
    }
}