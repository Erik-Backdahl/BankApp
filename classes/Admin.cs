 public class Admin 


{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }


    public Admin(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Admin Username: {Username}, Role: {Role}");
    }



}