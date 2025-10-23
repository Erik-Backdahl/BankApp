using System;

namespace BankApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Login.StartLogin();
        }
    }
}