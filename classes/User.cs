

using BankApp.classes;

public class User
{
   public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public int PersonalNumber { get; set; }
    public string Address { get; set; }
    public List<Account> Accounts { get; set; }



    // Constructor to user class
    public User()
    {

        Name = Name;
        Email = Email;
        Password = Password;
        PersonalNumber = PersonalNumber;
        Address = Address;
        Accounts = new List<Account>();

    }





}














