

using BankApp.classes;

public class User
{
   public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required int PersonalNumber { get; set; }
    public static bool Administator { get; set; } = false;
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

    






}















