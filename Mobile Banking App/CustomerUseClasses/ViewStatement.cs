using ClassLibrary;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.CustomerUseClasses
{
    public static class ViewStatement
    {
        public static void View(ICustomer customer)
        {
            //if required include a function to fill in the transaction in the customer class
            Console.WriteLine($"Date\t\tTransaction Id\t\tDetails\t\tAmount\t\tDebit/Credit");
            foreach (ITransactions transaction in customer.Account.transactions)
            {
                Console.WriteLine();
                Console.WriteLine($"{transaction.TransactionDate}\t\t {transaction.TransactionId}\t\t {transaction.TransactionDescription}\t\t {transaction.Amount}\t\t {transaction.TransactonType} ");
                Console.WriteLine();
            }
        }
    }
}
