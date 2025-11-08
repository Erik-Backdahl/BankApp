using System.Transactions;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using BankApp.classes;
using BankApp.HelperClasses;

namespace BankApp.classes;

class DelayedTransaction
{
    public static List<Transaction> transactions = [];
    public static void StartDelayedTransactions()
    {
        DateTime now = DateTime.Now;
        int minutes = now.Minute;
        int minutesToNextQuarter = 15 - (minutes % 15);

        if (minutesToNextQuarter == 15 && now.Second == 0)
        {
            minutesToNextQuarter = 0;
        }

        DateTime nextRun = now.AddMinutes(minutesToNextQuarter)
                               .AddSeconds(-now.Second)
                               .AddMilliseconds(-now.Millisecond);

        TimeSpan timeToGo = nextRun - now;

        Timer _timer = new Timer(ProcessTransactions, null, timeToGo, TimeSpan.FromMinutes(15));
    }
    public static void FormatAndAddDeposit(Account userAccount, decimal depositamount)
    {
        Deposit newDeposit = new Deposit
        {
            UserRecivingAccount = userAccount,
            AddAmmount = depositamount
        };
        transactions.Add(newDeposit);
    }
    public static void FormatAndAddWithdraw(Account userAccount, decimal withdrawAmount)
    {
        Withdraw newWithdraw = new Withdraw
        {
            UserFromAccount = userAccount,
            RemoveAmmount = withdrawAmount
        };
        transactions.Add(newWithdraw);
    }
    public static async void FormatAndAddTransfer(Account user1Account, Account user2Account, decimal transferAmount)
    {
        if (user1Account.Currency != user2Account.Currency)
        {

            HttpClient client = new HttpClient();
            var responseFirst = await client.GetAsync($"https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@2025.5.6/v1/currencies/{user1Account.Currency}.json");
            string responseBodyFirst = await responseFirst.Content.ReadAsStringAsync();
            JsonDocument docFirst = JsonDocument.Parse(responseBodyFirst);

            JsonElement rootFirst = docFirst.RootElement;

            string data = rootFirst.GetProperty($"{user1Account.Currency}").GetProperty($"{user2Account.Currency}").ToString();

            decimal conversionRate = decimal.Parse(data, CultureInfo.InvariantCulture);

            decimal finalNumber = transferAmount * conversionRate;

            Transfer newTransaction = new Transfer
            {
                UserFromAccount = user1Account,
                UserRecivingAccount = user2Account,
                RemoveAmmount = transferAmount,
                AddAmmount = finalNumber
            };
            transactions.Add(newTransaction);
        }
        else
        {
            Transfer newTransaction = new Transfer
            {
                UserFromAccount = user1Account,
                UserRecivingAccount = user2Account,
                RemoveAmmount = transferAmount,
                AddAmmount = transferAmount
            };
            transactions.Add(newTransaction);
        }
    }
    private static void ProcessTransactions(object? state)
    {
        foreach (var transaction in transactions)
        {

            switch (transaction)
            {
                case Deposit deposit:
                    deposit.UserRecivingAccount.Balance += deposit.AddAmmount;
                    break;

                case Withdraw withdraw:
                    withdraw.UserFromAccount.Balance -= withdraw.RemoveAmmount;
                    break;

                case Transfer transfer:
                    transfer.UserFromAccount.Balance -= transfer.RemoveAmmount;
                    transfer.UserRecivingAccount.Balance += transfer.AddAmmount;
                    break;

                default:
                    Console.WriteLine($"Unhandled transaction type: {transaction.GetType().Name}");
                    break;
            }

        }
        transactions.Clear();
    }
}