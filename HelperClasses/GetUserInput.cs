namespace BankApp.HelperClasses
{
    class GetUserInput
    {
        public static int ValidateInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int userNumber))
                {
                    return userNumber;
                }
                else
                {
                    Console.WriteLine("Du måste skriva in en giltig siffra");
                }
            }
        }
        public static string ValidateString()
        {
            while (true)
            {
                string? userString = Console.ReadLine();
                if (!string.IsNullOrEmpty(userString) && !string.IsNullOrWhiteSpace(userString))
                {
                    return userString;
                }
                else
                {
                    Console.WriteLine("Du måste skriva in en giltig string");
                }

            }
        }
    }
}