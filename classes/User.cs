

using BankApp.classes;

public class User
{
   public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    

    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public int PostalCode { get; set; }

    public int PersonalNumber { get; set; }


    public List<Account> Accounts { get; set; }






    public User()
    {
        Accounts = new List<Account>();

       
        
    }







    

}




