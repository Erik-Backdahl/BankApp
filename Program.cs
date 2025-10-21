using System;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartupAction.InitilizeTestData();
            Login.StartLogin();
        }
    }
}