using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using BankApp.HelperClasses;

namespace BankApp.StaticClasses
{
    class Transfer
    {
        public static async Task TransferFunds(User currentUser)
        {
            try
            {

                while (true)
                {
                    Console.WriteLine("(1) to transfer between your accounts\n (2) to tranfer to another user");

                    string userInput = GetUserInput.ValidateString();

                    if (userInput == "1")
                    {
                        await TransferInternally(currentUser);
                        return;
                    }
                    else if (userInput == "2")
                    {
                        await TrasnferExternallyAsync(currentUser);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Input not recognised please try again\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task TransferInternally(User currentUser)
        {
            if (currentUser.Accounts.Count <= 1)
            {
                throw new Exception("You can only transfer between your accounts when you have more than 1 account");
            }

            DisplayData.DisplayUserAccounts(currentUser);
            Console.WriteLine("Enter the number corresponding to the account you want to transfer funds FROM");
            int accountFromIndex;
            while (true)
            {
                int userInput = GetUserInput.ValidateInt();
                if (userInput >= 0 && userInput < currentUser.Accounts.Count)
                {
                    accountFromIndex = userInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid index please enter a valid value");
                }
            }
            Console.WriteLine("Success");


            DisplayData.DisplayUserAccounts(currentUser);
            Console.WriteLine("Enter the number corresponding to the account you want to transfer funds INTO");
            int accountIntoIndex;
            while (true)
            {
                int userInput = GetUserInput.ValidateInt();
                if (userInput == accountFromIndex)
                {
                    Console.WriteLine("\nCannot choose same account try again\n");
                }

                if (userInput >= 0 && userInput < currentUser.Accounts.Count)
                {
                    accountIntoIndex = userInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid index please enter a valid value");
                }
            }
            Console.WriteLine("Success");


            int tranferAmmount;
            while (true)
            {
                Console.WriteLine("Enter the ammount of funds you want to transfer:");
                int userInput = GetUserInput.ValidateInt();
                if (userInput >= 0 && userInput < currentUser.Accounts[accountFromIndex].Balance)
                {
                    tranferAmmount = userInput;
                    break;
                }
                else
                {
                    Console.WriteLine("invalid ammount. Please make sure you have enough funds to make this transfer");
                }
            }
            if (currentUser.Accounts[accountFromIndex].Currency == currentUser.Accounts[accountIntoIndex].Currency)
            {
                currentUser.Accounts[accountFromIndex].Balance -= tranferAmmount;
                currentUser.Accounts[accountIntoIndex].Balance += tranferAmmount;
            }
            else
            {
                HttpClient client = new HttpClient();
                var responseFirst = await client.GetAsync($"https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@2025.5.6/v1/currencies/{currentUser.Accounts[accountFromIndex].Currency}.json");
                string responseBodyFirst = await responseFirst.Content.ReadAsStringAsync();
                JsonDocument docFirst = JsonDocument.Parse(responseBodyFirst);

                JsonElement rootFirst = docFirst.RootElement;

                string data = rootFirst.GetProperty($"{currentUser.Accounts[accountFromIndex].Currency}").GetProperty($"{currentUser.Accounts[accountIntoIndex].Currency}").ToString();

                decimal conversionRate = decimal.Parse(data, CultureInfo.InvariantCulture);

                decimal finalNumber = tranferAmmount * conversionRate;

                currentUser.Accounts[accountFromIndex].Balance -= tranferAmmount;
                currentUser.Accounts[accountIntoIndex].Balance += finalNumber;
            }
            Console.WriteLine("Trasfer successful");
        }
        private static async Task TrasnferExternallyAsync(User currentUser)
        {
            int receivingUserIndex;
            User? receivingUser = null;
            while (receivingUser == null)
            {
                Console.WriteLine("Enter the person number of the person you want to transfer funds to");
                int userInput = GetUserInput.ValidateInt();

                int index = 0;
                foreach (User user in Menu.AllUsers)
                {
                    if (user.PersonalNumber == userInput)
                    {
                        Console.WriteLine("User Found");
                        receivingUserIndex = index;
                        receivingUser = user;

                        if (receivingUser.Accounts.Count == 0)
                        {
                            Console.WriteLine("Selected user does not have any active accounts so transfer is not possible");
                            return;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("user not found try again");
                    }
                    index++;
                }
            }

            DisplayData.DisplayUserAccounts(currentUser);
            Console.WriteLine("Enter the number corresponding to the account you want to transfer funds FROM");
            int accountFromIndex;
            while (true)
            {
                int userInput = GetUserInput.ValidateInt();
                if (userInput >= 0 && userInput < currentUser.Accounts.Count)
                {
                    accountFromIndex = userInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid index please enter a valid value");
                }
            }
            Console.WriteLine("Success");

            int tranferAmmount;
            while (true)
            {
                Console.WriteLine("Enter the ammount of funds you want to transfer:");
                int userInput = GetUserInput.ValidateInt();
                if (userInput >= 0 && userInput < currentUser.Accounts[accountFromIndex].Balance)
                {
                    tranferAmmount = userInput;
                    break;
                }
                else
                {
                    Console.WriteLine("invalid ammount. Please make sure you have enough funds to make this transfer");
                }
            }

            if (currentUser.Accounts[accountFromIndex].Currency == receivingUser.Accounts[0].Currency)
            {
                currentUser.Accounts[accountFromIndex].Balance -= tranferAmmount;
                receivingUser.Accounts[0].Balance += tranferAmmount;
            }
            else
            {
                HttpClient client = new HttpClient();
                var responseFirst = await client.GetAsync($"https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@2025.5.6/v1/currencies/{currentUser.Accounts[accountFromIndex].Currency}.json");
                string responseBodyFirst = await responseFirst.Content.ReadAsStringAsync();
                JsonDocument docFirst = JsonDocument.Parse(responseBodyFirst);

                JsonElement rootFirst = docFirst.RootElement;

                string data = rootFirst.GetProperty($"{currentUser.Accounts[accountFromIndex].Currency}").GetProperty($"{receivingUser.Accounts[0].Currency}").ToString();

                decimal conversionRate = decimal.Parse(data, CultureInfo.InvariantCulture);

                decimal finalNumber = tranferAmmount * conversionRate;

                currentUser.Accounts[accountFromIndex].Balance -= tranferAmmount;
                receivingUser.Accounts[0].Balance += finalNumber;
            }
            Console.WriteLine("Trasfer successful");




        }

    }
}