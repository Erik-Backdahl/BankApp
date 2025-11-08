using BankApp.classes;

class StartupAction
{
    public static void InitilizeTestData()
    {
        Menu.AllUsers.Add(new User
        {
            Name = "Ronald",
            Password = "123",
            Email = "Test@Gmail.com",
            PersonalNumber = 123,
            Accounts = new List<Account>
            {
                new Account
                {
                    OwnerPersonNumber = 123,
                    AccountType = "Savings",
                    Currency = "sek",
                    Balance = 20000
                },
                new Account
                {
                    OwnerPersonNumber = 123,
                    AccountType = "Savings",
                    Currency = "sek",
                    Balance = 20000
                }
            }
        });
        Menu.AllUsers.Add(new User
        {
            Name = "John",
            Password = "321",
            Email = "John@gmail.com",
            PersonalNumber = 321,
            Accounts = new List<Account>
            {
                new Account
                {
                    OwnerPersonNumber = 123,
                    AccountType = "Savings",
                    Currency = "usd",
                    Balance = 0
                }
            }
        });
        Menu.AllUsers.Add(new User { Name = "Paulina", Password = "087654", Email = "Paulina@gmail.com", PersonalNumber = 00023345 });
        Menu.AllUsers.Add(new User { Name = "Jeff", Password = "00223", Email = "Jeff@gmail.com", PersonalNumber = 444555666 });
        Menu.AllUsers.Add(new User { Name = "Max", Password = "98765", Email = "Max@gmail.com", PersonalNumber = 888444222 });
        Menu.AllUsers.Add(new User { Name = "Siem ", Password = "9590", Email = "SIEM", PersonalNumber = 2025 });
    }
}