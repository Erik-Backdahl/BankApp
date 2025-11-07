using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp.StaticClasses
{
   public class AdminStatistics
    {

        private List<Transaction> transactions;



        public AdminStatistics(List<Transaction> transactions) 
        {
            this.transactions = transactions;
        }



        public void ShowStatistics()

        {


            Console.WriteLine("\n========== STATISTIK ==========");

            // 1. Totalt antal transaktioner
            int numberoftransactions = transactions.Count;
            Console.WriteLine($"Total number of transactions:: {numberoftransactions}");

            //Total amount transferred//

            decimal totalBelopp = 0;
            foreach (var t in transactions)
            {
                totalBelopp += t.Amount;
            }




        }


    }
    
}
