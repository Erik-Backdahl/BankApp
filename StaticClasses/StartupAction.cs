using System.Reflection.Metadata.Ecma335;
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
            Accounts =
            {
                new Account { Balance = 1000.00m, AccountType = "Savings", Currency = "sek" },
                new Account { Balance = 500.00m, AccountType = "Savings", Currency = "usd" }
            }
        });
        Menu.AllUsers.Add(new User
        {
            Name = "John",
            Password = "1234",
            Email = "John@gmail.com",
            PersonalNumber = 222,
            Accounts =  {
                new Account { Balance = 0m, AccountType = "Savings", Currency = "eur" },
                new Account { Balance = 500.00m, AccountType = "Savings", Currency = "usd" }
            }
        });
        Menu.AllUsers.Add(new User { Name = "Paulina", Password = "087654", Email = "Paulina@gmail.com", PersonalNumber = 00023345 });
        Menu.AllUsers.Add(new User { Name = "Jeff", Password = "00223", Email = "Jeff@gmail.com", PersonalNumber = 444555666 });
        Menu.AllUsers.Add(new User { Name = "Max", Password = "98765", Email = "Max@gmail.com", PersonalNumber = 888444222 });

    }
}