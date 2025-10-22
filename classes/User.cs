

using BankApp.classes;

public class User
{
   public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public int PersonalNumber { get; set; }
    public string Address { get; set; }
    public List<Account> Accounts { get; set; }

    public User(string name, string email, string password, int personalNumber, string address)
    {
        Name = name;
        Email = email;
        Password = password;
        PersonalNumber = personalNumber;
        Address = address;
        Accounts = new List<Account>();






    }


}














